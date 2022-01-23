// Author: Logan Kim
// Mission #4 Assignment




$("#submit").click(function () {
    // Checks if all the required fields are filled
   

    if (($("#Category").val() == "")) {
        alert("Cannot Submit c");
    } else if (($("#Title").val() == "")) {
        alert("Cannot Submit t");
    } else if (($("#Year").val() < 1800) || ($("#year").val() >= 2023)) {
        alert("Cannot Submit y");
    } else if (($("#Director").val() == "")) {
        alert("Cannot Submit d");
    } else {
    };
    
});
