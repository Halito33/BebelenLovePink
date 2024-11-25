//VARIABLES
const carrito = document.getElementById("carrito"),
    listaProductos = document.getElementById("listaProducto"),
    contenedorCarrito = document.querySelector('.buy-card .lista'),
    vaciarCarrito = document.querySelector('vaciarCarrito');

let articulosCarrito = [];

registrarEventListeners()


function registrarEventListeners() {
    //Cuando yo le de click a "agregar al carrito de compras"
    listaProductos.addEventListener('click', agregarProducto);

    //Eliminar producto del carrito
    carrito.addEventListener('click', eliminarProducto);

    //Muestra los productos del carrito
    document.addEventListener("DOMContentLoaded", () => {
        articulosCarrito = JSON.parse(localStorage.getItem("carrito")) || [];
        carritoHTML();
    })

    //Vaciar el carrito
    vaciarCarrito.addEventListener('click', e => {
        articulosCarrito = [];
        limpiarHTML();
    })
}

function agregarProducto(e) {
    if (e.target.classList.contains("agregarProducto")) {
        const productoSeleccionado = e.target.parentElement.parentElement;
        leerInfo(productoSeleccionado)
    };
}
//Elimina un producto del carrito
function eliminarProducto(e) {
    if (e.target.classList.contains("borrarProducto")) {
        const productoId = e.target.getAttribute('data-id');

        //Eliminar del arregle de articulosCarrito por el data-id
        articulosCarrito = articulosCarrito.filter(items => items.id !== productoId)
        carritoHTML()
    }
}

//leer el contenido de las tarjetas de producto y extraer su informacion
function leerInfo(producto) {
    //crear un objeto con el contenido del producto actual
    const infoProducto = {
        imagen: producto.querySelector('img').src,
        titulo: producto.querySelector('h3').textContent,
        precio: producto.querySelector('.precio').textContent,
        id: producto.querySelector('button').getAttribute('data-id'),
        cantidad: 1
    };

    //Revisa si un elemento ya existe en el carrito
    const existe = articulosCarrito.some(producto => producto.id === infoProducto.id)

    if (existe) {
        //Actualizar cantidad
        const productos = articulosCarrito.map(items => {
            if (items.id === infoProducto.id) {
                items.cantidad++;
                return items;
            } else {
                return items;
            }
        });
        [...articulosCarrito, infoProducto]
    } else {
        articulosCarrito = [...articulosCarrito, infoProducto];
    }
    carritoHTML();
}

//Muestra el carrito en la pagina
function carritoHTML() {
    limpiarHTML()
    //Recorre el carrito de compras y genera el HTML
    articulosCarrito.forEach(producto => {
        const fila = document.createElement('div');
        fila.innerHTML = `
        <img src="${producto.imagen}"/>
        <p>${producto.titulo}</p>
        <p>${producto.precio}</p>
        <p>${producto.cantidad}</p>
        <p><span class="borrarProducto" data-id='${producto.id}'>X</span></p>
        `;

        contenedorCarrito.appendChild(fila);
    });

    //Sincronizar con LocalStorage
    sincronizarStorage();
}

function sincronizarStorage() {
    localStorage.setItem("carrito", JSON.stringify(articulosCarrito))
}

//Elimina los productos de la lista de productos
function limpiarHTML() {
    while (contenedorCarrito.firstChild) {
        contenedorCarrito.removeChild(contenedorCarrito.firstChild)
    }
    sincronizarStorage();
}