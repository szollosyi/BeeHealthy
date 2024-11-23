const toggle = document.getElementById('theme-toggle');
const themeLabel = document.getElementById('theme-label');

// Kezdeti állapot
updateThemeLabel();

toggle.addEventListener('change', () => {
    document.body.classList.toggle('dark-mode');
    updateThemeLabel();
});

function updateThemeLabel() {
    const isDarkMode = document.body.classList.contains('dark-mode');
    themeLabel.textContent = isDarkMode ? 'Sötét mód' : 'Világos mód';
}
