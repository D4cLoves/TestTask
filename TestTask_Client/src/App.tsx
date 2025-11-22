import React, { useState } from 'react';
import PatientList from "./components/PatientList/PatientList.tsx";
import DoctorList from "./components/DoctorList/DoctorList.tsx";
import DiseaseList from "./components/DiseaseList/DiseaseList.tsx";
import './App.css';

type Tab = 'patients' | 'doctors' | 'diseases';

const App: React.FC = () => {
    const [activeTab, setActiveTab] = useState<Tab>('patients');

    return (
        <div className="App">
            <h1>Медицинская система</h1>

            <div className="tabs">
                <button
                    onClick={() => setActiveTab('patients')}
                    className={activeTab === 'patients' ? 'active' : ''}
                >
                    Пациенты
                </button>
                <button
                    onClick={() => setActiveTab('doctors')}
                    className={activeTab === 'doctors' ? 'active' : ''}
                >
                    Доктора
                </button>
                <button
                    onClick={() => setActiveTab('diseases')}
                    className={activeTab === 'diseases' ? 'active' : ''}
                >
                    Болезни
                </button>
            </div>

            <div className="content">
                {activeTab === 'patients' && <PatientList />}
                {activeTab === 'doctors' && <DoctorList />}
                {activeTab === 'diseases' && <DiseaseList />}
            </div>
        </div>
    );
};

export default App;