// https://dzone.com/articles/crud-operation-in-aspnet-mvc-using-ajax-and-bootst

CargarRubros();
Filtrar();


		//ACÁ SE ENVÍAN DATOS A LA BD

function AgregarProd(){
	if($('#txtBoxAddCodigo').val() == "" || $('#txtBoxAddNombre').val() == "" || $('#txtBoxAddDescripcion').val() == ""){
		alert("¡Hay campos vacíos!");
		return false;
	}
	var json = {
        	'codigo' : $('#txtBoxAddCodigo').val(),
        	'nombre' : $('#txtBoxAddNombre').val(),
        	'descripcion' : $('#txtBoxAddDescripcion').val(),
        	'rubro' : $("#selection").val()
        };
        console.log(JSON.stringify(json));
        console.log(json);
	$.ajax({
       	type: "POST",
        url: "WebForm1.aspx/AgregarProducto",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),
        success: function (respuesta) {
        	console.log(respuesta.d);
            if(respuesta.d){
            	alert("Producto agregado");
            	Filtrar();
            }
        }
    });
}

		//RECIBIENDO DATOS DE LA BD

function CargarRubros(){
	var html = '';
		$.ajax({
		type: "POST",
		url: "WebForm1.aspx/TraerRubros",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function(respuesta1){
			console.log(respuesta1.d);
			for(i = 0; i < respuesta1.d.length; i++){
				html += '<option value ="' + respuesta1.d[i].id + '">' + respuesta1.d[i].nombre + '</option>';
			}
			$('#selection').html(html);
		}
	})
}

function Filtrar()
{
	var html = '</br>';
	$.ajax({
		type: "POST",
		url: "WebForm1.aspx/TraerProductos",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function(respuesta){
			html += '<table align ="center" border="1">'
			html += '<td><b>Codigo</b></td>'
			html += '<td><b>Nombre</b></td>'
			html += '<td><b>Descripcion</b></td>'
			html += '<td><b>Rubro</b></td>'
			html += '<td></td><td></td></tr>'
			console.log(respuesta.d);
			for(i = 0; i < respuesta.d.length; i++){
			html += '<tr>'
			console.log(respuesta.d[i].id);
			html += '<td>' + respuesta.d[i].codigo + '</td>';
			html += '<td>' + respuesta.d[i].nombre + '</td>';
			html += '<td>' + respuesta.d[i].descripcion + '</td>';
			html += '<td>' + respuesta.d[i].rubro + '</td>';
			html += '<td><button value="' + respuesta.d[i].id + '" id="eliminarID" onclick="Eliminar();return false;">Eliminar</button></td>';
			html += '<td><button value="' + respuesta.d[i].id + '" id="modificarID' + respuesta.d[i].id + '">Modificar</button></td>';
			html += '</tr>'
			}
			html += '</table>'
			$("#datos").html(html);
		}
	});
}

function Eliminar(id){
	if(confirm("¿Está seguro que desea eliminar el producto?")){
		//alert("Funciona");
		alert($('#eliminarID').val());
		$.ajax({
			url: "WebForm1.aspx/BorrarProducto" + id,
			type: "POST",
			contentType: "application/json;charset=utf-8",
			dataType: "json",
			success: function(respuesta2){
				AlgoQueBorre();
			}
		});
	}
}

function Esconder(){
	$('#agBoton').toggle();
	$('#lblCodigo').toggle();
	$('#lblNombre').toggle();
	$('#lblDescripcion').toggle();
	$('#txtBoxAddCodigo').toggle();
	$('#txtBoxAddNombre').toggle();
	$('#txtBoxAddDescripcion').toggle();
}
