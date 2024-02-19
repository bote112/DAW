document.addEventListener("DOMContentLoaded", function () {
    function fetchActori() {
        fetch('/api/actori')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                displayActori(data);
            })
            .catch(error => {
                console.error('There has been a problem with your fetch operation:', error);
            });
    }

    function displayActori(actori) {
        const lista = document.getElementById('lista-actori'); 
        lista.innerHTML = ''; 

        actori.forEach(actor => {
            const item = document.createElement('li');
            item.textContent = `${actor.nume} ${actor.prenume}`; 
            lista.appendChild(item);
        });
    }

    fetchActori();
});
