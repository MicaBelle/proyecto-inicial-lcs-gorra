import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

export const useAuth = () => {
    const navigate = useNavigate();

    useEffect(() => {
        const user = localStorage.getItem('user');
        if (user === null) {
            navigate('/');
        }
    }, [navigate]);
};