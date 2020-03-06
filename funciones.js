CargarRubros();
Filtrar();

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
			console.log(respuesta.d);
			for(i = 0; i < respuesta.d.length; i++){
				html += '<tr>'
				console.log(respuesta.d[i].id);
				html += '<td id="tdcodigo' + respuesta.d[i].id + '"><span id="codigo' + respuesta.d[i].id + '">' + respuesta.d[i].codigo + '</span><input type="text" id="codigoTxt' + respuesta.d[i].id + '" style="display:none"></td>';
				html += '<td id="tdnombre' + respuesta.d[i].id + '"><span id="nombre' + respuesta.d[i].id + '">' + respuesta.d[i].nombre + '</span><input type="text" id="nombreTxt' + respuesta.d[i].id + '" style="display:none"></td>';
				html += '<td id="tddescripcion' + respuesta.d[i].id + '"><span id="descripcion' + respuesta.d[i].id + '">' + respuesta.d[i].descripcion + '</span><input type="text" id="descripcionTxt' + respuesta.d[i].id + '" style="display:none"></td>';
				html += '<td id="tdrubro' + respuesta.d[i].id + '"><span id="rubro' + respuesta.d[i].id + '">' + respuesta.d[i].rubro + '</span></td>';
				html += '<td id="tdeliminar'+ respuesta.d[i].id +'"><button id="eliminarBtn' + respuesta.d[i].id + '" onclick="Eliminar(' + respuesta.d[i].id + ');return false;">Eliminar</button></td>';
				html += '<td id="tdmodificar'+ respuesta.d[i].id + '"><button id="modificarBtn' + respuesta.d[i].id + '" onclick="Modificar('+ respuesta.d[i].id + ');return false;">Modificar</button></td>';
				html += '</tr>'
			}
			html += '</table>'
			$("#tbody1").html(html);
		}
	});
}

function Filtrar3(id){
	var codigotxt = $('#codigoTxt' + id).text();
	var nombretxt = $('#nombreTxt' + id).text();
	var descripciontxt = $('#descripcionTxt' + id).text();
	var rubro = $('#selection' + id).val();
	$('#codigoTxt' + id).hide();
	$('#nombreTxt' + id).hide();
	$('#descripcionTxt' + id).hide();
	$('#tdrubro' + id).hide();
	$('#codigo' + id).show();
	$('#codigo' + id).val(codigotxt);
	$('#nombre' + id).show();
	$('#nombre' + id).val(nombretxt);
	$('#descripcion' + id).show();
	$('#descripcion' + id).val(descripciontxt);
	$('#rubro' + id).show();
	$('#rubro' + id).val(rubro);
	$('#aceptarBtn' + id).hide();
	$('cancelarBtn' + id).hide();
	$('#eliminarBtn').show();
	$('#modificarBtn').show();
}

function Modificar(id){
	var codigotxt = $('#codigo' + id).text();
	var nombretxt = $('#nombre' + id).text();
	var descripciontxt = $('#descripcion' + id).text();
	var rubro = $('#rubro' + id).text();
	$('#codigo' + id).hide();
	$('#nombre' + id).hide();
	$('#descripcion' + id).hide();
	/*$("#tdcodigo" + id).html('<input type="text" id="codigoTxt' + id + '" value="' + codigotxt +'">');
	$("#tdnombre" + id).html('<input type="text" id="nombreTxt' + id + '" value="' + nombretxt +'">');
	$("#tddescripcion" + id).html('<input type="text" id="descripcionTxt' + id + '" value="' + descripciontxt +'">');*/
	$("#tdrubro" + id).html($('<select id="selection' + id + '"></select>'));
	$('#descripcionTxt' + id).show();
	$('#descripcionTxt' + id).val(descripciontxt);
	$('#nombreTxt' + id).show();
	$('#nombreTxt' + id).val(nombretxt);
	$('#codigoTxt' + id).show();
	$('#codigoTxt' + id).val(codigotxt);
	var options = $("#selection").html();
	$('#selection' + id).append(options);
	$('#modificarBtn' + id).hide();
	$('#eliminarBtn' + id).hide();
	$('#tdmodificar' + id).html('<button id="cancelarBtn' + id + '" onclick="Filtrar(' + id + ');return false;">Cancelar</button>');
	$('#tdeliminar' + id).html('<button id="aceptarBtn' + id + '" onclick="ModificarDB(' + id + ');return false;">Aceptar</button>');
}

function ModificarDB(id){
	var json = {
		'id' : id,
		'codigo' : $('#codigoTxt' + id).val(),
		'nombre' : $('#nombreTxt' + id).val(),
		'descripcion' : $('#descripcionTxt' + id).val(),
		'rubro' : $("#selection" + id).val()
	};
	$.ajax({
		type: "POST",
		url: "WebForm1.aspx/ModificarDB",
		contentType: "application/json;charset=utf-8;",
		dataType: "json",
		data: JSON.stringify(json),
		success: function(respuesta3){
			if(respuesta3.d){
				alert("¡Producto modificado!");
				Filtrar();
			}
			else
				alert("No se ha modificado ningún campo");
		}
	});
}

function Eliminar(id){
	if(confirm("¿Está seguro que desea eliminar el producto?")){
		//alert("Funciona");
		var json = {
			'id' : id
		};
		$.ajax({
			url: "WebForm1.aspx/EliminarProducto",
			type: "POST",
			contentType: "application/json;charset=utf-8",
			dataType: "json",
			data:JSON.stringify(json),
			success: function(respuesta2){
				if(respuesta2.d)
					Filtrar();
				else
					alert("No se pudo eliminar");
			}
		});
	}
}