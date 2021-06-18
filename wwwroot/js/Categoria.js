class categoria {

    registrar_categoria() {
        $.post(
            "postCategoria",
            $('formCategoria').serialize(),
            (response) => {
                try {
                    var item = JSON.parse(response);
                    if (item.Code == "Done") {
                        window.location.href = "Index";

                    } else {
                        document.getElementById("mensaje").innerHTML = item.Description; 

                    }
                } catch (e) {
                    document.getElementById("mensaje").innerHTML = response; 

                }
            }
        )
    }

    EditarCategoria(data) {
        document.getElementById("CategoriaNombre").value = data.Nombre;
        document.getElementById("CategoriaDescripcion").value = data.Descripcion;
        document.getElementById("CategoriaEstado").cheked = data.Estado;
        document.getElementById("CategoriaId").value = data.CategoriaID;
    }
}