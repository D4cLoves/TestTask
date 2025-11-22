import {type Patient, type Doctor, type Disease} from '../types';

const API_BASE = 'http://localhost:5119/api';

export const api = {
    // Пациенты
    getPatients: (): Promise<Patient[]> =>
        fetch(`${API_BASE}/patient`).then(res => {
            if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
            return res.json();
        }),

    getPatient: (id: string): Promise<Patient> =>
        fetch(`${API_BASE}/patients/${id}`).then(res => res.json()),

    updatePatientName: (id: string, firstName: string, lastName: string): Promise<void> =>
        fetch(`${API_BASE}/patients/${id}/name?firstName=${firstName}&lastName=${lastName}`, {
            method: 'PATCH'
        }).then(res => {
            if (!res.ok) throw new Error('Ошибка обновления');
        }),

    // Доктора
    getDoctorsBySpecialty: (specialty: string): Promise<Doctor[]> =>
        fetch(`${API_BASE}/doctors/specialty/${specialty}`).then(res => res.json()),

    // Болезни
    getDiseases: (): Promise<Disease[]> =>
        fetch(`${API_BASE}/diseases`).then(res => res.json())
};