$(function () {
    $(".date-picker").datepicker();
});


$('.accordion-button').click(function () {
    $(this).css('color', '#646464');
    $(this).css('background-color', '#ffffff');
    $('.accordion-body').css('background-color', '#ffffff');
});



function NavBtnServReq() {
    $("#ServiceReqBtn").addClass("active");
    $("#UserMngBtn").removeClass("active");

    $("#ServRequestSection").show();
    $("#UserManageSection").hide();
  
    
}

function NavBtnUserMng() {
    
    $("#ServiceReqBtn").removeClass("active");
    $("#UserMngBtn").addClass("active");

    $("#ServRequestSection").hide();
    $("#UserManageSection").show();


}

$(document).ready(function () {

    getadminservicereq();

    getAdminUserData();

});







function getadminservicereq() {

    var data = {};
    data.serviceRequestId = document.getElementById("ServReqServId").value;
    data.customerName = document.getElementById("ServReqCustName").value;
    data.serviceProviderName = document.getElementById("ServReqSPName").value;
    data.status = document.getElementById("ServReqStatus").value;
    data.fromDate = document.getElementById("ServReqFromDate").value;
    data.toDate = document.getElementById("ServReqToDate").value;
    console.log(data.serviceRequestId  + data.customerName + data.serviceProviderName + data.status + data.fromDate + data.toDate);
    $.ajax({
        type: 'GET',
        url: '/Admin/GetServiceRequest',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {




            $("#ServReqTbody").empty();



            for (var i = 0; i < result.length; i++) {

                var varStatus = "";
               // var star = "";
                var popupfield = "";
                var display = "";

                if (result[i].userProfilePicture == null) {
                    result[i].userProfilePicture = "cap.png";
                }

               if (result[i].serviceProvider == null) {
                    display = "d-none";
                    result[i].serviceProvider = "";
                }

              /*  for (var j = 1; j < 6; j++) {

                    if (j <= result[i].averageRating) {

                        star += '<i class="fa fa-star " style="color:#ECB91C; "></i>';

                    }
                    else {
                        star += '<i class="fa fa-star " style="color:silver;"></i>'
                    }

                }
                star += " " + result[i].averageRating; */



                switch (result[i].status) {

                    case 1: /*new */
                        varStatus = "new";
                        popupfield =  ' <li><a class="dropdown-item ServEdit" data-value=' + result[i].serviceRequestId + '>Edit & Reschedule </a ></li>' +
                            ' <li><a class="dropdown-item ServCancel" data-value=' + result[i].serviceRequestId + '>Cancel</a></li>';
                        break;
                    case 2: /*pending */
                        varStatus = "pending";
                        popupfield = ' <li><a class="dropdown-item ServEdit" data-value=' + result[i].serviceRequestId + '>Edit & Reschedule </a ></li>' +
                            ' <li><a class="dropdown-item ServCancel" data-value=' + result[i].serviceRequestId + '>Cancel</a></li>';
                        break;
                    case 3: /*completed */
                        varStatus = "completed";
                        popupfield = ' <li><a class="dropdown-item ServRefund" data-value=' + result[i].serviceRequestId + '>Refund</a></li>';;
                        break;
                    case 4: /*cancelled*/
                        varStatus = "cancelled";
                        popupfield = ' <li><a class="dropdown-item ServRefund" data-value=' + result[i].serviceRequestId + '>Refund</a></li>';;
                        break;
                    default: /*other status */
                        varStatus = "invalid";
                }

                var html = '' +
                    '<tr>' +
                    '<td>' + result[i].serviceRequestId + '</td>' +
                    '<td>' +
                    '<p>' +
                    '<img src="/Images/calendar2.png" alt="calender"><span class="service-date">' + result[i].date + '</span></p>' +
                    '<p><img src="/Images/layer-14.png">' + result[i].startTime + '-' + result[i].endTime +
                    '</p></td>' +
                    '<td><div class="customer-detail"><p class="detail-para">' + result[i].customerName + '</p>' +
                    '<p><img src="/Images/layer-15.png">' + result[i].address + '</p></div></td>' +
                    '<td><div class="pro_info ' + display + '"><div class="cap-icon"><img src="/Images/' + result[i].userProfilePicture + '"></div>' +
                    '<div class="pro-name"><p>' + result[i].serviceProvider + '</p><p class="d-none"><img src="/Images/star1.png">5</p></div></div></td>' +
                    '<td> <div class="' + varStatus+'-status">' + varStatus+ '</div></td>' +
                    '<td><ul class="dropdown">' +
                    '<a class="dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false" >' +
                    '<img src="/Images/group-38.png" alt="dropdown"></a>' + 
                    '<ul class="dropdown-menu" aria-labelledby="navbarDropdown">' +  popupfield +
                    '<li><a class="dropdown-item" href="#">Escalate</a ></li>' +  
                    '<li><a class="dropdown-item" href="#">History Log</a ></li>' +
                    '<li><a class="dropdown-item" href="#">Download Invoice</a ></li>' +   
                    '</ul></ul></td>' +
                    '</tr>';





                $("#ServReqTbody").append(html);
            }




        },
        error: function () {
            alert("error");
        }
    });
}



$('#ServReqSubmit').click(function () {
    getadminservicereq();
});

$('#ServReqClear').click(function () {
    window.setTimeout(function () {
        getadminservicereq();
    }, 200);
});








var serviceReqId;
var state;
$(document).on('click', '.ServEdit', function () {

    console.log("Service Edit");
    $("#ServiceEditBtn").click();
    serviceReqId = this.getAttribute("data-value");
    console.log(serviceReqId);
    ServEditPopup();
});



function ServEditPopup() {

    var data = {};
    data.ServiceRequestId = parseInt(serviceReqId);

    $.ajax({
        type: 'GET',
        url: '/Admin/GetServEditData',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {







            console.log("success" + result.startTime);
            console.log("success" + result.date);


            var temp = new Date(result.date);
            temp.setDate(temp.getDate() + 1);
            console.log("successful" + temp);

            document.getElementById('ServiceEditDate').valueAsDate = temp;

            //var dt = new Date();
            //var time = dt.getHours() + ":" + dt.getMinutes()
            document.getElementById('ServiceEditTime').value = result.startTime;





            document.getElementById('ServiceEditStreet').value =  result.address.addressLine1;
            document.getElementById('ServiceEditHouse').value = result.address.addressLine2;
            document.getElementById('ServiceEditZipCode').value = result.address.postalCode;


            document.getElementById('ServiceEditInvoiceStreet').value = result.address.addressLine1;
            document.getElementById('ServiceEditInvoiceHouse').value = result.address.addressLine2;
            document.getElementById('ServiceEditInvoiceZipCode').value = result.address.postalCode;

            getCityFromPostalCode(result.address.postalCode, "#ServiceEditCity");
            getCityFromPostalCode(result.address.postalCode, "#ServiceEditInvoiceCity");





        },
        error: function () {
            alert("error");
        }
    });

}






$(document).on('click', '#ServEditUpdateBtn', function () {


    var data = {};
    data.address = {};
    data.ServiceRequestId = parseInt(serviceReqId);
    data.address.addressLine1 = document.getElementById('ServiceEditStreet').value;

    data.address.addressLine2 = document.getElementById('ServiceEditHouse').value;
    data.address.postalCode = document.getElementById('ServiceEditZipCode').value;
    //data.address.city = document.getElementById('AdminEditPopupCity').value;
    //data.address.state = state;
    var temp = document.getElementById("ServiceEditDate").value;
    data.date = temp + " " + document.getElementById("ServiceEditTime").value;


    $.ajax({
        type: 'POST',
        url: '/Admin/UpdateServiceReq',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {

            alert("Service Request Edit Successful.");



            window.setTimeout(function () {
                $("#ServiceEditModalClose").click();
                $("#ServReqSubmit").click();
            }, 500);

        },
        error: function () {
            alert("error");
        }
    });

});





$(document).on('click', '.ServCancel', function () {

    console.log("cancle service");

    serviceReqId = this.getAttribute("data-value");

    var data = {};
    data.ServiceRequestId = parseInt(serviceReqId);

    $.ajax({
        type: 'POST',
        url: '/Admin/CancelServiceReq',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {

            alert("Service Cancelled !!");

            window.setTimeout(function () {
                $("#ServReqSubmit").click();
            }, 500);

        },
        error: function () {
            alert("error");
        }
    });



});












function getAdminUserData() {



    var data = {};


    data.name = document.getElementById("UserMngName").value;
    data.userType = document.getElementById("UserMngType").value;
    data.postalCode = document.getElementById("UserMngZipcode").value;
    data.phone = document.getElementById("UserMngPhone").value;

    console.log(data.name + data.userType);
    $.ajax({
        type: 'GET',
        url: '/Admin/GetUserData',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {




            $("#AdminUserMngTbody").empty();



            for (var i = 0; i < result.length; i++) {


                //for date



                var createdDateTemp = new Date(result[i].createdDate.toString());
                var yyyy = createdDateTemp.getFullYear();
                var mm = createdDateTemp.getMonth() + 1; // Months start at 0!
                var dd = createdDateTemp.getDate();

                if (dd < 10) dd = '0' + dd;
                if (mm < 10) mm = '0' + mm;

                var createdDateTemp = dd + '/' + mm + '/' + yyyy;



                var userTypeTemp = "Customer";

                if (result[i].userTypeId == 2) {
                    userTypeTemp = "ServiceProvider";
                }
                else if (result[i].userTypeId == 3) {
                    userTypeTemp = "Admin";
                }

                var statusTemp = "Active";

                if (result[i].isActive == false) {
                    statusTemp = "Inactive";
                }


                var popup;

                if (result[i].userTypeId != 2) {
                    if (result[i].isActive == true) {
                        popup = '<li><a class="dropdown-item UserMngDropdown" data-value=' + result[i].userId + ' href = "#">Deactivate</a></li>';
                    }
                    else {

                        popup = '<li><a class="dropdown-item UserMngDropdown" data-value=' + result[i].userId + ' href = "#">Activate</a></li>';

                    }
                }
                else if (result[i].userTypeId == 2) {
                    if (result[i].isApproved == false) {
                        popup = '<li><a class="dropdown-item UserMngDropdown" data-value=' + result[i].userId + ' href = "#">Approve SP</a></li>'
                    }
                    else {
                        if (result[i].isActive == true) {
                            popup = '<li><a class="dropdown-item UserMngDropdown" data-value=' + result[i].userId + ' href = "#">Deactivate</a></li>';
                        }
                        else {

                            popup = '<li><a class="dropdown-item UserMngDropdown" data-value=' + result[i].userId + ' href = "#">Activate</a></li>';

                        }
                    }

                }
               

                var html = '' +
                    '<tr>' +
                    '<td>' + result[i].firstName + ' ' + result[i].lastName + '</td>' +
                    '<td>' + userTypeTemp + '</td>' +
                    '<td>' + result[i].mobile + '</td>' +
                    '<td class="post-code">' + result[i].zipCode + '</td>'+
                    '<td class="post-code"> <img class="me-2" src="/Images/calendar2.png" alt="calender">' + createdDateTemp + '</td>' +
                    '<td><div class="' + statusTemp + '-status">' + statusTemp + '</div></td>' +
                    '<td><ul class="dropdown">' +
                    '<a class="dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">' +
                    '<img src="/Images/group-38.png" alt="dropdown">' +
                    '</a><ul class="dropdown-menu" aria-labelledby="navbarDropdown">' + popup + '</ul></ul></td>' +
                    '</tr>' ;





                $("#AdminUserMngTbody").append(html);
            }



        },
        error: function () {
            alert("error");
        }
    });
}





$('#UserMngSubmit').click(function () {
    getAdminUserData();
});

$('#UserMngClear').click(function () {
    window.setTimeout(function () {
        getAdminUserData();
    }, 200);
});




$(document).on("click", ".UserMngDropdown", function () {

    var id = this.getAttribute("data-value");
    var data = {};
    data.UserId = parseInt(id);

    $.ajax({
        type: 'POST',
        url: '/Admin/UserEdit',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {

            $("#UserMngSubmit").click();


            alert(result);




        },
        error: function () {
            alert("error");
        }
    });



});






//City from pincode
function getCityFromPostalCode(zip, Id) {
    $.ajax({
        method: "GET",
        url: "https://api.postalpincode.in/pincode/" + zip,
        dataType: 'json',
        cache: false,
        success: function (result) {
            if (result[0].status == "Error" || result[0].status == "404") {

                alert("Invalid PostalCode");

            }
            else {
                $(Id).val(result[0].PostOffice[0].District).prop("disabled", true);

                state = result[0].PostOffice[0].State;


            }
        },
        error: function (error) {

        }
    });
}
