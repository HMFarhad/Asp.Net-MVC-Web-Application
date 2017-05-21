
function nameValidation() {
    var name = $('#username').val();
    var nameRE = /^[A-Za-z\s]+$/;
    if (name != "") {
        if (nameRE.test(name)) {
            //alert(name);
            return true;
        }
        else document.getElementById("msg1").innerHTML = "Only A-Z or a-z should be on Name!!";
    }
    else {
        document.getElementById("msg1").innerHTML = "Name Can't be Empty!!";
        return false;
    }
}

function PassValidation() {
    var Address = $('#password').val();
    if (Address != "") {
        if (Address.length >= 5 && Address.length << 30) {
            //alert(name);
            return true;
        }
        else document.getElementById("msg2").innerHTML = "Password Length Must be between 5-30 !!";
    }
    else {
        document.getElementById("msg2").innerHTML = "Password Field Can't be Empty!!";
        return false;
    }
}


function EmailValidation() {
    var  userEmail = $('#email').val();
    var emailRE = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (userEmail != "") {
        if (emailRE.test(userEmail)) {
            //alert(userEmail);
            return true;
        }
        else
        {
            document.getElementById("msg3").innerHTML = "Invalid User Email Format !!";
            return false;
        }
    }
    else {
        document.getElementById("msg3").innerHTML = "Email Field Can't be Empty !!";
        return false;
    }
}

function AddressValidation() {
    var Address = $('#address').val();
    if (Address != "") {
        if (Address.length >= 2 && Address.length << 30) {
            //alert(name);
            return true;
        }
        else document.getElementById("msg4").innerHTML = "Address Length Must be between 2-30 !!";
    }
    else {
        document.getElementById("msg4").innerHTML = "Address Field Can't be Empty!!";
        return false;
    }
}


function PhoneValidation()
{
    var phoneNo = $('#phone').val();;
    var phoneNoRE = /^\d+$/;

    if ((phoneNo.length < 12) && (phoneNo.length > 10)) {
        if (phoneNoRE.test(phoneNo)) {
            var tmp1 = phoneNo.charAt(0);
            var tmp2 = phoneNo.charAt(2);
            if (tmp1 == 0) {
                if (tmp2 == 5 || tmp2 == 6 || tmp2 == 7 || tmp2 == 8 || tmp2 == 9) {
                    //alert (phoneNo);
                    return true;
                }
                else {
                    document.getElementById("msg5").innerHTML = "Phone No Must Be a valid Phone No!";

                    return false;
                }
            }
            else {
                document.getElementById("msg5").innerHTML = "Phone No Must Be a valid Phone No!";

                return false;
            }
        }
    }
    else {
        document.getElementById("msg5").innerHTML = "Phone No Can't be Empty!!";

        return false;
    }
}

function TypeValidation() {
    var type = $('#type').val();
    var typeRE = /^[A-Za-z\s]+$/;
    if (type != "") {
        if (typeRE.test(type)) {
            //alert(name);
            return true;
        }
        else document.getElementById("msg6").innerHTML = "Only A-Z or a-z should be on Type!!";
    }
    else {
        document.getElementById("msg6").innerHTML = "Type Can't be Empty!!";
        return false;
    }
}

function validateUser() {
    var form = document.getElementById("myForm");

    if (nameValidation() == true && PassValidation() == true && EmailValidation() == true && AddressValidation() == true && PhoneValidation() == true && TypeValidation() == true)
    {
        //alert("Registration Successfull");
        $("#myForm").submit();
    }
}
