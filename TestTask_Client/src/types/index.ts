export interface Patient {
    id: string;
    name: {
        firstName: string;
        lastName: string;
    };
    birthDate: string;
    doctorId: string;
}

export interface Doctor {
    id: string;
    name: {
        firstName: string;
        lastName: string;
    };
    specialty: string;
    birthDate: string;
}

export interface Disease {
    id: string;
    name: string;
    description: string;
}