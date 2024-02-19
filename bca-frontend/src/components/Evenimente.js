import React, { useState, useEffect } from 'react';
import ApiService from '../services/ApiService';

function Evenimente() {
    const [evenimente, setEvenimente] = useState([]);

    useEffect(() => {
        ApiService.getEvenimente().then(response => {
            setEvenimente(response.data);
        });
    }, []);

    return (
        <div>
            <h2>Evenimente</h2>
            <ul>
                {evenimente.map(eveniment => <li key={eveniment.id}>{eveniment.nume}</li>)}
            </ul>
        </div>
    );
}

export default Evenimente;
