document.addEventListener("DOMContentLoaded", function () {
    fetchFilme();

    function fetchFilme() {
        fetch('/api/filme')
            .then(response => response.json())
            .then(data => displayFilme(data))
            .catch(error => console.error('Unable to fetch films.', error));
    }

    function displayFilme(filme) {
        const lista = document.getElementById('lista-filme');
        lista.innerHTML = '';

        filme.forEach(film => {
            const item = document.createElement('li');
            item.textContent = `${film.titlu} - Regizor: ${film.regizor}`;  
            lista.appendChild(item);
        });
    }

    function adaugaFilm(film) {
        fetch('/api/filme', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(film),
        })
            .then(response => response.json())
            .then(() => {
                fetchFilme();
            })
            .catch(error => console.error('Unable to add film.', error));
    }

    function actualizeazaFilm(id, film) {
        fetch(`/api/filme/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(film),
        })
            .then(() => {
                fetchFilme(); 
            })
            .catch(error => console.error('Unable to update film.', error));
    }

    function stergeFilm(id) {
        fetch(`/api/filme/${id}`, {
            method: 'DELETE',
        })
            .then(() => {
                fetchFilme(); 
            })
            .catch(error => console.error('Unable to delete film.', error));
    }
    document.getElementById('form-adauga-film').addEventListener('submit', function (e) {
        e.preventDefault(); 

        const film = {
            titlu: document.getElementById('titlu').value,
            regizor: document.getElementById('regizor').value
        };

        adaugaFilm(film);

        e.target.reset();
    });

});
