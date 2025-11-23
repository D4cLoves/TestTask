export interface Patient {
    id: string;
    name: {
        value?: string;
        Value?: string;
    };
    birthDate: string;
    doctorId: string;
}

export interface Doctor {
    id: string;
    name: {
        value?: string;
        Value?: string;
    };
    specialty: string;
    birthDate: string;
}

export interface Disease {
    id: string;
    name: string;
    description: string;
}