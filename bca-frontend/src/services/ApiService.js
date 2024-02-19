import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api'; // URL-ul backend-ului

class ApiService {
    getEvenimente() {
        return axios.get(`${API_BASE_URL}/evenimente`);
    }

    // Adaugă alte metode necesare
}

export default new ApiService();
