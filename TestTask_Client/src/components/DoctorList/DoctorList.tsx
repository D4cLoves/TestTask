import React, { useState } from 'react';
import type { Doctor } from "../../types";
import { api } from "../../services/api.ts";

const DoctorList: React.FC = () => {
    const [doctors, setDoctors] = useState<Doctor[]>([]);
    const [specialty, setSpecialty] = useState('');

    const searchDoctors = async () => {
        if (!specialty.trim()) return;
        const data = await api.getDoctorsBySpecialty(specialty);
        setDoctors(data);
        
    };

    return (
        <div>
            <h2>Поиск докторов по специальности</h2>
            <div style={{ marginBottom: '20px' }}>
                <input
                    type="text"
                    value={specialty}
                    onChange={(e) => setSpecialty(e.target.value)}
                    placeholder="Введите специальность"
                    style={{ padding: '8px', marginRight: '10px', width: '300px' }}
                />
                <button onClick={searchDoctors}>Найти</button>
            </div>

            {doctors.length > 0 && (
                <table border={1} cellPadding="10" cellSpacing="0" style={{ width: '100%', borderCollapse: 'collapse' }}>
                    <thead>
                        <tr style={{ backgroundColor: '#f0f0f0' }}>
                            <th>№</th>
                            <th>ФИО</th>
                            <th>Специальность</th>
                            <th>Дата рождения</th>
                        </tr>
                    </thead>
                    <tbody>
                        {doctors.map((doctor, index) => (
                            <tr key={doctor.id}>
                                <td>{index + 1}</td>
                                <td>{doctor.name.value || doctor.name.Value || 'Не указано'}</td>
                                <td>{doctor.specialty}</td>
                                <td>{new Date(doctor.birthDate).toLocaleDateString('ru-RU')}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
};

export default DoctorList;
