const btnServers = document.getElementById('btn-servers');
const btnAges = document.getElementById('btn-ages');
const btnAutre = document.getElementById('btn-autre');
const stats = document.getElementById('stats');
const loading = document.getElementById('loading');

btnServers.addEventListener('click', () => {
    // Afficher le message d'attente
    loading.style.display = 'block';
    stats.textContent = '';

    // Envoyer la requête GET
    fetch('http://localhost:9000/question1')
        .then(console.log("reponse recup ok"))
        .then(response => response.text())
        .then(data => {
            // Cacher le message d'attente et afficher la réponse
            loading.style.display = 'none';
            stats.textContent = data;
        }).catch(error => console.error(error));
});

btnAges.addEventListener('click', () => {
    // Afficher le message d'attente
    loading.style.display = 'block';
    stats.textContent = '';

    // Envoyer la requête GET
    fetch('http://localhost:9000/question2')
        .then(response => response.text())
        .then(data => {
            // Cacher le message d'attente et afficher la réponse
            loading.style.display = 'none';
            stats.textContent = data;
        }).catch(error => console.error(error));
});

btnAutre.addEventListener('click', () => {
    loading.style.display = 'block';
    stats.textContent = '';

    // Envoyer la requête GET
    fetch('http://localhost:9000/question3')
        .then(response => response.text())
        .then(data => {
            // Cacher le message d'attente et afficher la réponse
            loading.style.display = 'none';
            stats.textContent = data;
        }).catch(error => console.error(error));
})
