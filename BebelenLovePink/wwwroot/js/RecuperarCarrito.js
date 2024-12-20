// Recuperar los datos desde localStorage
const nombre = localStorage.getItem('.nombre');
const precio = localStorage.getItem('.precio');
const imgUrl = localStorage.getItem('.fotoProducto');
const cantidad = localStorage.getItem('cantidad');

// Mostrar los datos en la página
if (nombre && precio && imgUrl) {
    document.getElementById('.nombre').innerText = nombre;
    document.getElementById('.precio').innerText = precio;
    document.getElementById('.fotoProducto').src = imgUrl;
    document.getElementById('.cantidad').src = imgUrl;
} else {
    alert('No se encontraron datos en LocalStorage');
}