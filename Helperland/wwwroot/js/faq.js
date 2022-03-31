function Tab1Click() {
    $("#FaqCustTab").addClass("active");
    $("#FaqProTab").removeClass("active");

    $("#FaqCust").show();
    $("#FaqPro").hide();

}

function Tab2Click() {

    $("#FaqCustTab").removeClass("active");
    $("#FaqProTab").addClass("active");

    $("#FaqCust").hide();
    $("#FaqPro").show();

}