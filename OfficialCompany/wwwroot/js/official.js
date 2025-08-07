window.addEventListener('scroll', function () {
    const newsSection = document.getElementById('news');
    const rect = newsSection.getBoundingClientRect();
    if (rect.top < window.innerHeight && !newsSection.dataset.loaded) {
        fetch('/Home/GetLastNews') // call your controller or API
            .then(response => response.text())
            .then(html => {
                section.innerHTML = html;                
            });
        newsSection.dataset.loaded = "true"; // prevent duplicate load
    }
});
