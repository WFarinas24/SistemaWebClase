class Trabajadores {

    registrar_Trabajadores() {
        $.post(
            "postTrabadores",
            $('formTrabajadores').serialize(),
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
}