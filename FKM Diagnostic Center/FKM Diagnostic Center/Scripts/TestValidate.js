function TestNameValidation() {
    var Name = $('#testName').val();
    if (Name != "")
    {
        if (Name.length >> 1 && Name.length <= 8)
        {
            return true;
        }
        else
        {
            document.getElementById("msg1").innerHTML = "Test name Length Must be in between 2-8 !!";
            return false;
        }
    }
    else {
        document.getElementById("msg1").innerHTML = "Test name Can't be Empty!!";
        return false;
    }
}
function TestBilltValidation()
{
    var Bill = $('#testBill').val();
    if (Bill != "") {
        if (Bill >= 100 && Bill <= 2500) {
            return true;
        }
        else {
            document.getElementById("msg2").innerHTML = "Test Bill Amount Must be in between 100-2500 !!";
            return false;
        }
    }
    else {
        document.getElementById("msg2").innerHTML = "Test Bill Can't be Empty!!";
        return false;
    }
}


function validateTest() {
    var form = document.getElementById("myForm");

    if (TestNameValidation() == true && TestBilltValidation() == true) {
        //alert("Registration Successfull");
        $("#myForm").submit();
    }
}