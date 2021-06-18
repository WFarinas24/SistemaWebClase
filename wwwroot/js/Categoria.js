class categoria {

    constructor() {
        this.CategoriaID = 0; 
    }
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

    GetData(data) {
        document.getElementById("titleCategoria").innerHTML = data.Nombre;
        this.CategoriaID = data.CategoriaID; 
    }


    EliminarCategoria() {
        $.post(
            "EliminarCategoria",
            { CategoriaID: this.CategoriaID },
            (respuesta) => {
                var item = JSON.parse(respuesta);
                if (item.Description == "Done") {
                    window.location.href = "Categoria";
                } else {
                    document.getElementById("mensajeEliminar").innerHTML = item.Description;
                }
            }

        );
    }
}