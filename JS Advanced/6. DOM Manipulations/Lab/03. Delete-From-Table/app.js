function deleteByEmail() {
    let tbody = document.querySelector("table tbody").children;
    let input = document.querySelector('input');
    let result = document.getElementById('result');
    let deleted = false;

    Array.from(tbody).forEach(x => {
        if (x.children[1].textContent.includes(input.value)) {
            x.remove();
            deleted = true;
        }
    });
    
    deleted ? result.textContent = 'Deleted.' : result.textContent = 'Not found.';
}