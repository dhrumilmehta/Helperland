
function Tab1Click() {
    $("#tab1").addClass("active");
    $("#tab2").removeClass("active").addClass("tabs");
    $("#tab3").removeClass("active").addClass("tabs");
    $("#tab4").removeClass("active").addClass("tabs");

    $("#tab-content2").hide();
    $("#tab-content3").hide();
    $("#tab-content4").hide();
    $("#tab-content1").show();
}

function Tab2Click() {
    if ($("#tab3").hasClass("active") || $("#tab4").hasClass("active")) {

        $("#tab2").addClass("active");
        $("#tab1").addClass("active");
        $("#tab3").removeClass("active").addClass("tabs");
        $("#tab4").removeClass("active").addClass("tabs");
        $("#tab-content1").hide();
        $("#tab-content3").hide();
        $("#tab-content4").hide();
        $("#tab-content2").show();

    }
}

function SearchZipCode() {

    var data = $("#form1").serialize();

    $.ajax({
        type: 'POST',
        url: '/ServiceManage/ValidPostalCode',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
                $("#tab2").addClass("active");
                $("#tab-content1").hide();
                $("#tab-content3").hide();
                $("#tab-content4").hide();
                $("#tab-content2").show();
            }
            else {
                alert("zipcode is not valid");
            }
        }
    });

}

function SaveServiceDetail() {


    var data = $("#form2").serialize();
    console.log(data);

    $.ajax({
        type: 'POST',
        url: '/ServiceManage/ScheduleService',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {

                $("#tab3").addClass("active");
                $("#tab-content1").hide()
                $("#tab-content2").hide();
                $("#tab-content4").hide();
                $("#tab-content3").show();

                loadAddress();
            }
            else {
                alert("Schedule is not valid");
            }
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed');
        }
    });


}

function Tab3Click() {
    if ($("#tab4").hasClass("active")) {

        $("#tab3").addClass("active");
        $("#tab2").addClass("active");
        $("#tab1").addClass("active");
        $("#tab4").removeClass("active").addClass("tabs");
        $("#tab-content1").hide();
        $("#tab-content2").hide();
        $("#tab-content4").hide();
        $("#tab-content3").show();

    }
}
//$('#element').click(function () {
//    if ($('#address'+i+'').is(':checked')) { alert("it's checked"); }
//});
function SaveAddressForm() {
    
        $("#tab4").addClass("active");
        $("#tab3").addClass("active");
        $("#tab2").addClass("active");
        $("#tab1").addClass("active");

        $("#tab-content1").hide();
        $("#tab-content2").hide();
        $("#tab-content3").hide();
        $("#tab-content4").show();
    
}


$(document).ready(function () {
    $('#ZipCode').on('input change', function () {
        if ($(this).val() != '') {
            $('#zipcode-search').prop('disabled', false);
        }
        else {
            $('#zipcode-search').prop('disabled', true);
        }
    });
});

$(function () {
    $(".date-picker").datepicker();
});






$(document).ready(function () {

    let clickNum = 1;
    $('#insideCabinetCheck').on("click", function(){
        clickNum++;

        if (clickNum % 2 == 0) {
            $('#extra-svg1').addClass('extraclicked');
        }
        else {
            $('#extra-svg1').removeClass('extraclicked');
        }
    });
});
$(document).ready(function () {

    let clickNum = 1;
    $('#insideFridgeCheck').on("click", function () {
        clickNum++;

        if (clickNum % 2 == 0) {
            $('#extra-svg2').addClass('extraclicked');
        }
        else {
            $('#extra-svg2').removeClass('extraclicked');
        }
    });
});
$(document).ready(function () {

    let clickNum = 1;
    $('#insideOvenCheck').on("click", function () {
        clickNum++;

        if (clickNum % 2 == 0) {
            $('#extra-svg3').addClass('extraclicked');
        }
        else {
            $('#extra-svg3').removeClass('extraclicked');
        }
    });
});
$(document).ready(function () {

    let clickNum = 1;
    $('#laundryCheck').on("click", function () {
        clickNum++;

        if (clickNum % 2 == 0) {
            $('#extra-svg4').addClass('extraclicked');
        }
        else {
            $('#extra-svg4').removeClass('extraclicked');
        }
    });
});
$(document).ready(function () {

    let clickNum = 1;
    $('#interiorCheck').on("click", function () {
        clickNum++;

        if (clickNum % 2 == 0) {
            $('#extra-svg5').addClass('extraclicked');
        }
        else {
            $('#extra-svg5').removeClass('extraclicked');
        }
    });
});


function addAddressdiv() {
    
    $("#addAddressBtn").hide();
    $("#addNewaddressDiv").show();

    /*$("#ZipCode").change(function () {
        $("#addAddressPostalCode").val($("#ZipCode").val());
    });*/

    $("#addAddressPostalCode").addClass("disable-div");

    document.getElementById('addAddressPostalCode').value = document.getElementById("ZipCode").value;

}



function loadAddress() {
    var data = $("#form1").serialize();
    
    $.ajax({
        type: 'get',
        url: '/ServiceManage/DetailsService',
        contenttype: 'application/x-www-form-urlencoded; charset=utf-8',
        data: data,
        success: function (result) {
            var address = $("#address");
            address.empty();
            address.append('<p class="details-text">Please select your address:</p>');
            if (result.length == 0) {

                document.getElementById("addAddressBtn").click();

            }
            else {
                for (let i = 0; i < result.length; i++) {
                var checked = "";
                if (result[i].isDefault == true) {
                    checked = "checked";
                }
                address.append(' <div class="radiobutton">' +
                    '<input type="radio" id=" '+i+' " ' + checked + ' name="address" value="' + result[i].addressId + '" />' +
                    '<label for=" ' + i + ' "><span><strong>Address: </strong></span>&nbsp;<span>' + result[i].addressLine1 + '</span>,&nbsp;<span>' + result[i].addressLine2 + '</span>&nbsp;<span>' + result[i].city + '</span>-&nbsp;<span>' + result[i].postalCode + '</span>' +
                    '<br><span><strong>Phone Number: </strong></span> ' + result[i].mobile + ' <span></span></label></div>');
                checked = "";
                }
                console.log(result);
            }
        },
        error: function () {
            alert('failed to receive the data');
            console.log('failed ');
        }
    });
}



function saveAddress() {
    //alert("In Address 1")
    var data = {};
    data.AddressLine1 = document.getElementById("AddressLine1").value;
    data.AddressLine2 = document.getElementById("AddressLine2").value;
    data.PostalCode = document.getElementById("addAddressPostalCode").value;
    data.City = document.getElementById("City").value;
    data.Mobile = document.getElementById("Mobile").value;
    //alert("In Address 2")


    $.ajax({
        type: 'POST',
        url: '/ServiceManage/AddNewAddress',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
                document.getElementById("addressCancelBtn").click();
                loadAddress();
            }
            else {
                alert('Sorry! Something went wrong please try again later.');
            }
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    });
}



function cancelAddress() {
    document.getElementById("addNewaddressDiv").style.display = "none";
    document.getElementById('addAddressBtn').style.display = "block";
}



/*$(document).ready(function () {
    
        if ($('#address').val() != '') {
            $('#AddContbtn').prop('disabled', false);
        }
        else {
            $('#AddContbtn').prop('disabled', true);
        }
   
});*/




function completeBookService() {
    var data = {};
    var extrahour = 0;
    var cabinet = document.getElementById("insideCabinetCheck");
    var window = document.getElementById("interiorCheck");
    var fridge = document.getElementById("insideFridgeCheck");
    var oven = document.getElementById("insideOvenCheck");
    var laundry = document.getElementById("laundryCheck");
    if (cabinet.checked == true) {
        extrahour += 0.5;
        data.cabinet = true;
    }
    if (window.checked == true) {
        extrahour += 0.5;
        data.window = true;
    }
    if (fridge.checked == true) {
        extrahour += 0.5;
        data.fridge = true;
    }
    if (oven.checked == true) {
        extrahour += 0.5;
        data.oven = true;
    }
    if (laundry.checked == true) {
        extrahour += 0.5;
        data.laundry = true;
    }
    data.postalCode = document.getElementById("ZipCode").value;
    //var temp=document.getElementById("Date");
    //alert(temp.value);
    //var date=new Date(temp.value);
    //alert(date);
    //date.setHours(data.startTime,0,0,0);
    //alert(date+"after set hours")
    // const a = date.toISOString().split('T')[0];
    // const b = date.toTimeString().split(' ')[0];
    //date=a+" "+b;
    var temp = document.getElementById("date").value;
    data.serviceStartDate = temp + " " + document.getElementById("Time").value;
    data.serviceHours = document.getElementById("timeduration-input").value;
    data.extraHours = extrahour;
    var duration = parseFloat(document.getElementById("timeduration-input").value);
    var extra = parseFloat(extrahour);
    // data.subTotal = (extrahour * 25) + ((document.getElementById("Duration").value) * 25);
    data.subTotal = (extra + duration) * 25;
    data.totalCost = data.subTotal; //Discount 0(out of scope)
    data.comments = document.getElementById("comment").value;
    //data.paymentDue = false;
    data.HasPet = document.getElementById("have-pet").checked;
    //alert(document.getElementById("have-pet").checked);
    //alert(data.HasPet);
    //data.paymentDone = true;
    //data.addressId = $('#addresses div input[type=radio]:checked').val();
    data.addressId = document.querySelector('input[name="address"]:checked').value;
    //alert(data.addressId);
    $.ajax({
        type: 'post',
        url: '/ServiceManage/CompleteBooking',
        contenttype: 'application/x-www-form-urlencoded; charset=utf-8',
        data: data,
        success: function (result) {
            if (result.value == "false") {
                alert("schedule is not valid");
            }
            else {
                //$("#modalserviceid").text("service id : " + result.value);
                // $("#completebookingmodalbtn").click();
                alert("Completed")
            }
        },
        error: function () {
            alert('failed to receive the data');
            console.log('failed ');
        }
    });
}

