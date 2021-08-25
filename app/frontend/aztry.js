(async function() {
    const { count } = await( await fetch(`app/Backend/api/countfn`)).json();
    document.querySelector('#name').textContent = count;
}())