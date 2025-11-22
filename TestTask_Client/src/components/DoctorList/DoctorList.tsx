import React, { useState } from 'react';
import type { Doctor } from "../../types";
import { api } from "../../services/api.ts";

const DoctorList: React.FC = () => {
    const [doctors, setDoctors] = useState<Doctor[]>([]);
    const [specialty, setSpecialty] = useState('');

    const searchDoctors = async () => {
        if (!specialty.trim()) return;

        try {
            const data = await api.getDoctorsBySpecialty(specialty);
            setDoctors(data);
        } catch (error) {
            console.error('Ошибка загрузки докторов:', error);
        }
    };

    return (
        <div>
            <h2>Доктора по специальности</h2>
            <div>
                <input
                    value={specialty}
                    onChange={(e) => setSpecialty(e.target.value)}
                    placeholder="Введите специальность (терапевт, хирург...)"
                    style={{ marginRight: '10px' }}
                />
                <button onClick={searchDoctors}>Найти</button>
            </div>

            <div>
                {doctors.map(doctor => (
                    <div key={doctor.id} style={{ border: '1px solid #ddd', margin: '5px', padding: '10px' }}>
                        <strong>{doctor.name.firstName} {doctor.name.lastName}</strong>
                        <br />
                        Специальность: {doctor.specialty}
                    </div>
                ))}
            </div>
        </div>
    );
};

export default DoctorList;