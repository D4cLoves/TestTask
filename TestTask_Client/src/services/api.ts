import { Patient, Doctor, Disease } from '../types';

const API_BASE = 'https://localhost:7000/api';

export const api = {
    // Пациенты
    getPatients: (): Promise<Patient[]> =>
        fetch(`${API_BASE}/patients`).then(res => res.json()),

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