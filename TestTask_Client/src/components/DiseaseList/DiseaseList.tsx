import React, { useState, useEffect } from 'react';
import type {Disease} from "../../types";
import { api } from "../../services/api.ts";

const DiseaseList: React.FC = () => {
    const [diseases, setDiseases] = useState<Disease[]>([]);

    useEffect(() => {
        loadDiseases();
    }, []);

    const loadDiseases = async () => {
        const data = await api.getDiseases();
        setDiseases(data);
    };

    return (
        <div>
            <h2>Справочник болезней</h2>
            <table border={1} cellPadding="10" cellSpacing="0" style={{ width: '100%', borderCollapse: 'collapse' }}>
                <thead>
                    <tr style={{ backgroundColor: '#f0f0f0' }}>
                        <th>№</th>
                        <th>Название</th>
                        <th>Описание</th>
                    </tr>
                </thead>
                <tbody>
                    {diseases.map((disease, index) => (
                        <tr key={disease.id}>
                            <td>{index + 1}</td>
                            <td><strong>{disease.name}</strong></td>
                            <td>{disease.description}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default DiseaseList;
