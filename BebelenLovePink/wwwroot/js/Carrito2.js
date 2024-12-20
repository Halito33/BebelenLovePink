//Variables


function guardarDatos() {
    const nombre = document.getElementById('.nombre').innerText;
    const precio = document.getElementById('.precio').innerText;
    const imgUrl = document.getElementById('.fotoProducto').src;
    const cantidad = 1;


    localStorage.setItem('.nombre', nombre);
    localStorage.setItem('.precio', precio);
    localStorage.setItem('.fotoProducto', imgUrl);
    localStorage.setItem(cantidad);


    alert('datos guardados en local storage')


}

document.getElementById('guardarBtn').addEventListener('click', guardarDatos);