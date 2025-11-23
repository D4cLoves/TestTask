import React, { useState, useEffect } from 'react';
import {type Patient} from "../../types";
import { api } from "../../services/api.ts";

const PatientList: React.FC = () => {
    const [patients, setPatients] = useState<Patient[]>([]);
    const [editingId, setEditingId] = useState<string | null>(null);
    const [newName, setNewName] = useState('');

    useEffect(() => {
        loadPatients();
    }, []);

    const loadPatients = async () => {
        const data = await api.getPatients();
        setPatients(data);

    };

    const startEdit = (patient: Patient) => {
        setEditingId(patient.id);
        setNewName(patient.name.value || patient.name.Value || '');
    };

    const cancelEdit = () => {
        setEditingId(null);
        setNewName('');
    };

    const saveEdit = async (id: string) => {
        const nameParts = newName.trim().split(' ');
        const firstName = nameParts[0] || '';
        const lastName = nameParts.slice(1).join(' ') || '';

        if (!firstName || !lastName) {
            alert('Введите имя и фамилию');
            return;
        }

        try {
            await api.updatePatientName(id, firstName, lastName);
            await loadPatients();
            cancelEdit();
        } catch (error) {
            alert('Ошибка обновления имени');
        }
    };

    return (
        <div>
            <h2>Список пациентов</h2>
            <table border={1} cellPadding="10" cellSpacing="0" style={{ width: '100%', borderCollapse: 'collapse' }}>
                <thead>
                    <tr style={{ backgroundColor: '#f0f0f0' }}>
                        <th>№</th>
                        <th>ФИО</th>
                        <th>Дата рождения</th>
                        <th>Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {patients.map((patient, index) => (
                        <tr key={patient.id}>
                            <td>{index + 1}</td>
                            <td>
                                {editingId === patient.id ? (
                                    <input
                                        type="text"
                                        value={newName}
                                        onChange={(e) => setNewName(e.target.value)}
                                        style={{ width: '200px', padding: '5px' }}
                                    />
                                ) : (
                                    patient.name.value || patient.name.Value || 'Не указано'
                                )}
                            </td>
                            <td>{new Date(patient.birthDate).toLocaleDateString('ru-RU')}</td>
                            <td>
                                {editingId === patient.id ? (
                                    <>
                                        <button onClick={() => saveEdit(patient.id)} style={{ marginRight: '5px' }}>Сохранить</button>
                                        <button onClick={cancelEdit}>Отмена</button>
                                    </>
                                ) : (
                                    <button onClick={() => startEdit(patient)}>Редактировать</button>
                                )}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default PatientList;
