

$(document).ready(function(){
	
$('#searchList').attr('required',false)
$('#searchBox').attr('required',false)
loadDVD();
//searchDVDTitle();
//searchDVDRating();
//chooseSearchType();
updateDVD();
addDVD();
//showCreateForm();	

//$("#editFormDiv").show();
});


function loadDVD(){
	
	var contentRows = $("#contentRows"); 
	//clearDVDList();
	$("#contentRows").empty();
    $.ajax({
		
        type: "GET",
        url: "http://dvd-library.us-east-1.elasticbeanstalk.com/dvds",
        success: function(contactArray) {
            //alert('success-loadDVD!');
			$("#contentRows").empty();
			$.each(contactArray, function(index, dvd){
				var title = dvd.title;
				var year = dvd.releaseYear;
				var director = dvd.director;
				var rating = dvd.rating;
				//var dvdId = dvd.dvdId;
				var dvdId = dvd.id;
				var notes = dvd.notes
				
				var row = "<tr>";
				row += "<td>" + title + "</td>";
				row+= "<td>" + year + "</td>";
				row += "<td>" + director + "</td>";
				row += "<td>" + rating + "</td>";
				row+= '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + dvdId + '); hideSearchComponents.hide();">Edit</button></td>'+ ' ' +
				 '<td><button type="button" class="btn btn-link" onclick="deleteDVD('+ dvdId +')">Delete</button></td>';
				row += "</tr>";
				
				contentRows.append(row);
				
			});
        },
        error: function() {
            alert('FAILURE!');
        }
    });
	
}

function addDVD(){
	$("#createButton").click(function (event){
		
	var haveValidationErrors = checkAndDisplayValidationErrors(
	$("#createForm").find("input")
	);
	
	if(haveValidationErrors){
	return false;
	}
	
	$.ajax({
		type:"POST",
		url: "http://dvd-library.us-east-1.elasticbeanstalk.com/dvd/" ,
		
		data: JSON.stringify({
		//id: $("#editDVDId").val(),
        title: $("#createTitle").val(),
        releaseYear: $("#createReleaseYear").val(),
        director: $("#createDirector").val(),
        rating: $("#createRating").val(),
        notes: $("#createNotes").val(),
      }),
	  headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
	  dataType: "json",
	  
	  success: function () {
		 // alert("went thru");
        $("#errorMessages").empty();
        hideCreateForm();
        loadDVD();
      },
	  error: function () {
        $("#errorMessages").append(
          $("<li>")
            .attr({ class: "list-group-item list-group-item-danger" })
            .text("Error!")
		);
		},
    });
  });
}

function updateDVD(dvdId) {
	
  $("#updateButton").click(function (event) {
	 
	
    var haveValidationErrors = checkAndDisplayValidationErrors(
      $("#editForm").find("input")
    );

    if (haveValidationErrors) {
      return false;
    }

    $.ajax({
		
      type: "PUT",
      url:"http://dvd-library.us-east-1.elasticbeanstalk.com/dvd/"  
		+ $("#editDVDId").val(),
       //format the data in JSON
      data: JSON.stringify({
        id: $("#editDVDId").val(),
        title: $("#editTitle").val(),
        releaseYear: $("#editReleaseYear").val(),
        director: $("#editDirector").val(),
        rating: $("#editRating").val(),
        notes: $("#editNotes").val(),
      }),
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      dataType: "json",
      success: function () {
		 // alert("went thru");
        $("#errorMessages").empty();
        hideEditForm();
        loadDVD();
      },
	  
      error: function () {
        //$("#errorMessages").append(
          //$("<li>")
            //.attr({ class: "list-group-item list-group-item-danger" })
            //.text("Error!")
        //);
		
		//$("#editFormDiv").hide();
		clearDVDList();
		hideEditForm();
		loadDVD();
		//$("#dvdTableDiv").show();
      },
    });
  });
}

function showEditForm(dvdId){
	
	//$('#searchList').removeAttr('required');
	//$('#searchBox').removeAttr('required');
	$("#searchComponents").hide();

	
	$.ajax({
		type:"GET",
		url: "http://dvd-library.us-east-1.elasticbeanstalk.com/dvd/"+ dvdId,
		success: function (data,status){
			//alert('success-showEditForm! for' + dvdId);
			$("#editDVDId").val(data.id);
			$("#editTitle").val(data.title);
			$("#editReleaseYear").val(data.releaseYear);
			$("#editDirector").val(data.director);
			$("#editRating").val(data.rating);
			$("#editNotes").val(data.notes);
		},
	
		error:function(){
			$("#errorMessages").append(
				$("<li>")
				.attr({class:"list-group-item list-group-item-danger" })
				.text("Error calling web service, please try later.")
				);
		},
	});
	$("#dvdTableDiv").hide();
	$("#editFormDiv").show();
	
	

}

function showCreateForm(){
	//alert('create dvd button clicked!');
	$("#searchComponents").hide();
	
	$("#dvdTableDiv").hide();
	$("#createFormDiv").show();
	
}

function hideEditForm(){
	
	$("#errorMessages").empty();
	
	$("#editTitle").empty();
	
	$("#dvdTableDiv").show();
	$("#editFormDiv").hide();
}

function hideCreateForm(){

	$("#errorMessages").empty();
	$("#searchComponents").show();
	
	
	$("#dvdTableDiv").show();
	$("#createFormDiv").hide();

}

function clearDVDList(){

	$("#contentRows").empty();
}

function chooseSearchType(){
	//alert('searching!')
	//alert($('#searchList').val());
	if($('#searchList').val() == 'title')
	{
		searchDVDTitle();
		//alert('searching for title!');
	}
	else if($('#searchList').val() == 'director')
	{
		searchDVDDirector();
	}
	else if($('#searchList').val() == 'releaseYear')
	{
		searchDVDYear();
	}
	else if($('#searchList').val() == 'rating')
	{
		searchDVDRating();
	}
	

}

function searchDVDTitle(){
	var contentRows = $("#contentRows"); 
	
	$("#contentRows").empty();
	
	$.ajax({
		type:"GET",
		url:"http://dvd-library.us-east-1.elasticbeanstalk.com/dvds/title/" + $('#searchBox').val(),
		success:function(contactArray){
			$("#contentRows").empty();
			$.each(contactArray, function(index, dvd){
				var title = dvd.title;
				var year = dvd.releaseYear;
				var director = dvd.director;
				var rating = dvd.rating;
				//var dvdId = dvd.dvdId;
				var dvdId = dvd.id;
				var notes = dvd.notes
				
				var row = "<tr>";
				row += "<td>" + title + "</td>";
				row+= "<td>" + year + "</td>";
				row += "<td>" + director + "</td>";
				row += "<td>" + rating + "</td>";
				row+= '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + dvdId + '); hideSearchComponents.hide();">Edit</button></td>'+ ' ' +
				 '<td><button type="button" class="btn btn-link" onclick="deleteDVD('+ dvdId +')">Delete</button></td>';
				row += "</tr>";
				
				contentRows.append(row);
			});
		},
		error:function(){
			alert('title not found!');
		}
	});
	
}

function searchDVDRating(){
	var contentRows = $("#contentRows"); 
	
	$("#contentRows").empty();
	
	$.ajax({
		type:"GET",
		url:"http://dvd-library.us-east-1.elasticbeanstalk.com/dvds/rating/" + $('#searchBox').val(),
		success:function(contactArray){
			$("#contentRows").empty();
			$.each(contactArray, function(index, dvd){
				var title = dvd.title;
				var year = dvd.releaseYear;
				var director = dvd.director;
				var rating = dvd.rating;
				//var dvdId = dvd.dvdId;
				var dvdId = dvd.id;
				var notes = dvd.notes
				
				var row = "<tr>";
				row += "<td>" + title + "</td>";
				row+= "<td>" + year + "</td>";
				row += "<td>" + director + "</td>";
				row += "<td>" + rating + "</td>";
				row+= '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + dvdId + '); hideSearchComponents.hide();">Edit</button></td>'+ ' ' +
				 '<td><button type="button" class="btn btn-link" onclick="deleteDVD('+ dvdId +')">Delete</button></td>';
				row += "</tr>";
				
				contentRows.append(row);
			});
		},
		error:function(){
			alert('no results with that Rating!');
		}
	});
	
}

function searchDVDYear(){
	var contentRows = $("#contentRows"); 
	
	$("#contentRows").empty();
	
	$.ajax({
		type:"GET",
		url:"http://dvd-library.us-east-1.elasticbeanstalk.com/dvds/year/" + $('#searchBox').val(),
		success:function(contactArray){
			$("#contentRows").empty();
			$.each(contactArray, function(index, dvd){
				var title = dvd.title;
				var year = dvd.releaseYear;
				var director = dvd.director;
				var rating = dvd.rating;
				//var dvdId = dvd.dvdId;
				var dvdId = dvd.id;
				var notes = dvd.notes
				
				var row = "<tr>";
				row += "<td>" + title + "</td>";
				row+= "<td>" + year + "</td>";
				row += "<td>" + director + "</td>";
				row += "<td>" + rating + "</td>";
				row+= '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + dvdId + '); hideSearchComponents.hide();">Edit</button></td>'+ ' ' +
				 '<td><button type="button" class="btn btn-link" onclick="deleteDVD('+ dvdId +')">Delete</button></td>';
				row += "</tr>";
				
				contentRows.append(row);
			});
		},
		error:function(){
			alert('no results from that Year!');
		}
	});
	
}

function searchDVDDirector(){
	var contentRows = $("#contentRows"); 
	
	$("#contentRows").empty();
	
	$.ajax({
		type:"GET",
		url:"http://dvd-library.us-east-1.elasticbeanstalk.com/dvds/director/" + $('#searchBox').val(),
		success:function(contactArray){
			$("#contentRows").empty();
			$.each(contactArray, function(index, dvd){
				var title = dvd.title;
				var year = dvd.releaseYear;
				var director = dvd.director;
				var rating = dvd.rating;
				//var dvdId = dvd.dvdId;
				var dvdId = dvd.id;
				var notes = dvd.notes
				
				var row = "<tr>";
				row += "<td>" + title + "</td>";
				row+= "<td>" + year + "</td>";
				row += "<td>" + director + "</td>";
				row += "<td>" + rating + "</td>";
				row+= '<td><button type="button" class="btn btn-link" onclick="showEditForm(' + dvdId + '); hideSearchComponents.hide();">Edit</button></td>'+ ' ' +
				 '<td><button type="button" class="btn btn-link" onclick="deleteDVD('+ dvdId +')">Delete</button></td>';
				row += "</tr>";
				
				contentRows.append(row);
			});
		},
		error:function(){
			alert('no results with that Director!');
		}
	});
	
}


function deleteDVD(dvdId){
	
	if (confirm("Delete this dvd?")){
		txt="Deleted";
	
	
	$.ajax({
		type: "DELETE",
		url: "http://dvd-library.us-east-1.elasticbeanstalk.com/dvd/"+ dvdId,
		success: function(){
			loadDVD();
		},
		error:function(){
			alert('failure! did not delete '+ dvdId);
		}
	});
	}
	else{
		txt = "not deleted";
	}
	
}


function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();
    
    var errorMessages = [];
    
    input.each(function() {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + this.validationMessage);//' Select a search category 	and term');
        }  
    });
    
    if (errorMessages.length > 0){
        $.each(errorMessages,function(index,message) {
            $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
}




