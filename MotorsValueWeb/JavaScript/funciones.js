
function cargarHTML(idElemento, archivo) {
    fetch(archivo)
        .then((response) => {
            if (!response.ok) {
                throw new Error(`Error al cargar ${archivo}: ${response.statusText}`);
            }
            return response.text();
        })
        .then((data) => {
            // Insertar el contenido HTML en el elemento especificado
            const elemento = document.getElementById(idElemento);
            elemento.innerHTML = data;

            // Buscar y ejecutar los scripts en el contenido cargado
            const scripts = elemento.querySelectorAll('script');
            scripts.forEach((script) => {
                const nuevoScript = document.createElement('script');
                if (script.src) {
                    // Si el script tiene un src, se vuelve a cargar
                    nuevoScript.src = script.src;
                    nuevoScript.async = true; // Asegura la ejecución independiente
                } else {
                    // Si el script es inline, copia su contenido
                    nuevoScript.textContent = script.textContent;
                }
                document.body.appendChild(nuevoScript); // Añadir el script al DOM
                script.remove(); // Opcional: eliminar el script original
            });
        })
        .catch((error) => console.error(`Error cargando el archivo:`, error));  
}

