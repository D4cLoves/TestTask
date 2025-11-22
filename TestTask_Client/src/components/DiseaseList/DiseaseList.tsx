import React, { useState, useEffect } from 'react';
import type {Disease} from "../../types";
import { api } from "../../services/api.ts";
const DiseaseList: React.FC = () => {
    const [diseases, setDiseases] = useState<Disease[]>([]);

    useEffect(() => {
        loadDiseases();
    }, []);

    const loadDiseases = async () => {
        try {
            const data = await api.getDiseases();
            setDiseases(data);
        } catch (error) {
            console.error('Ошибка загрузки болезней:', error);
        }
    };

    return (
        <div>
            <h2>Общий список болезней</h2>
            <div>
                {diseases.map(disease => (
                    <div key={disease.id} style={{ border: '1px solid #ddd', margin: '5px', padding: '10px' }}>
                        <strong>{disease.name}</strong>
                        <br />
                        {disease.description}
                    </div>
                ))}
            </div>
        </div>
    );
};

export default DiseaseList;