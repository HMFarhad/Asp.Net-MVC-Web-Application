
function PNameValidation(){
    var name = $('#PName').val();
	var nameRE = /^[A-Za-z\s]+$/;
	if(name!="")
	{
	    if (nameRE.test(name)) {
	        //alert(name);
	        return true;
	    }
	    else document.getElementById("msg1").innerHTML = "Only A-Z or a-z should be on Name!!";
    }
	else
	{
	    document.getElementById("msg1").innerHTML= "Name Can't be Empty!!";
        return false;
    }
}

function PAddressValidation() {
    var Address = $('#PAddress').val();
    if (Address != "") {
        if (Address.length >= 2 && Address.length << 30) {
            //alert(name);
            return true;
        }
        else document.getElementById("msg2").innerHTML = "Address Length Must be between 2-30 !!";
    }
    else
    {
        document.getElementById("msg2").innerHTML = "Address Field Can't be Empty!!";
        return false;
    }
}
                    

function PAgeValidation()
{
    var Age = $('#PAge').val();
    if (Age != "") {
        if (Age >= 1 && Age <= 130) {
            //alert(name);
            return true;
        }
        document.getElementById("msg3").innerHTML = "Age Length Must be between 1-130 !!";
    }
    else {
        document.getElementById("msg3").innerHTML = "Age Field Can't be Empty!!";

        return false;
    }
}
			
function PPhoneValidation()
{
    var phoneNo = $('#PPhone').val();;
	var phoneNoRE = /^\d+$/;
	if (phoneNo != "") {
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
	                    document.getElementById("msg4").innerHTML = "Phone No Must Be a valid Phone No!";

	                    return false;
	                }
	            }
	            else {
	                document.getElementById("msg4").innerHTML = "Phone No Must Be a valid Phone No!";

	                return false;
	            }
	        }
	    }
	    else {
	        document.getElementById("msg4").innerHTML = "Phone No Must Be a valid Phone No!!";

	        return false;
	    }

	}
	else
	{
	    ocument.getElementById("msg4").innerHTML = "Phone No Can't be Empty!!";

	    return false;
	}
    
}

function PTestValidation()
{
    var Test = $('#testId').val();
    if (Test>0)
    {
        return true;
    }
    else
    {
        document.getElementById("msg5").innerHTML = "Please Select a Test!!";
        return false;
    }
}
					
function validatePatient()
{		
    var form = document.getElementById("myForm");
    
	if (PNameValidation() == true && PAddressValidation() == true && PAgeValidation() == true && PPhoneValidation() == true && PTestValidation() == true)
	{
		//alert("Registration Successfull");
		$("#myForm").submit();
    }		
}
