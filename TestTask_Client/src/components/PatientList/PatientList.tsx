import React, { useState, useEffect } from 'react';
import {type Patient} from "../../types";
import { api } from "../../services/api.ts";

const PatientList: React.FC = () => {
    const [patients, setPatients] = useState<Patient[]>([]);
    const [selectedPatient, setSelectedPatient] = useState<Patient | null>(null);
    const [newFirstName, setNewFirstName] = useState('');
    const [newLastName, setNewLastName] = useState('');

    useEffect(() => {
        loadPatients();
    }, []);

    const loadPatients = async () => {
        try {
            const data = await api.getPatients();
            setPatients(data);
        } catch (error) {
            console.error('Ошибка загрузки пациентов:', error);
        }
    };

    const updatePatientName = async (id: string) => {
        if (!newFirstName.trim() || !newLastName.trim()) return;

        try {
            await api.updatePatientName(id, newFirstName, newLastName);
            setNewFirstName('');
            setNewLastName('');
            loadPatients(); // Перезагружаем список
            alert('Имя обновлено!');
        } catch (error) {
            alert('Ошибка обновления имени');
        }
    };

    return (
        <div>
            <h2>Список пациентов</h2>

            {/* Форма обновления имени */}
            {selectedPatient && (
                <div style={{ border: '1px solid #ccc', padding: '10px', margin: '10px 0' }}>
                    <h3>Обновить имя пациента</h3>
                    <p>Текущее: {selectedPatient.name.firstName} {selectedPatient.name.lastName}</p>
                    <input
                        value={newFirstName}
                        onChange={(e) => setNewFirstName(e.target.value)}
                        placeholder="Новое имя"
                    />
                    <input
                        value={newLastName}
                        onChange={(e) => setNewLastName(e.target.value)}
                        placeholder="Новая фамилия"
                    />
                    <button onClick={() => updatePatientName(selectedPatient.id)}>
                        Обновить
                    </button>
                </div>
            )}

            {/* Список пациентов */}
            <div>
                {patients.map(patient => (
                    <div
                        key={patient.id}
                        style={{
                            border: '1px solid #ddd',
                            margin: '5px',
                            padding: '10px',
                            cursor: 'pointer',
                            backgroundColor: selectedPatient?.id === patient.id ? '#f0f0f0' : 'white'
                        }}
                        onClick={() => setSelectedPatient(patient)}
                    >
                        <strong>{patient.name.firstName} {patient.name.lastName}</strong>
                        <br />
                        Дата рождения: {new Date(patient.birthDate).toLocaleDateString()}
                    </div>
                ))}
            </div>
        </div>
    );
};

export default PatientList;