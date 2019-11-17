<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacultyRegistration.aspx.cs" Inherits="FacultyRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
    <style>
* {
  box-sizing: border-box;
}

body {
  background-color: #f1f1f1;
}

#regForm {
  background-color: #ffffff;
  margin: 100px auto;
  font-family: Raleway;
  padding: 40px;
  width: 70%;
  min-width: 300px;
}

h1 {
  text-align: center;  
}

input {
  padding: 10px;
  font-size: 17px;
  font-family: Raleway;
  border: 1px solid #aaaaaa;
}

/* Mark input boxes that gets an error on validation: */
input.invalid {
  background-color: #ffdddd;
}

/* Hide all steps by default: */
.tab {
  display: none;
}

button   {
  background-color: #4CAF50;
  color: #ffffff;
  border: none;
  padding: 10px 20px;
  font-size: 17px;
  font-family: Raleway;
  cursor: pointer;
}#Submit   {
  background-color: #4CAF50;
  color: #ffffff;
  border: none;
  padding: 10px;
  font-size: 17px;
  font-family: Raleway;
  cursor: pointer;
}

button:hover {
  opacity: 0.8;
}

#prevBtn {
  background-color: #bbbbbb;
}

/* Make circles that indicate the steps of the form: */
.step {
  height: 15px;
  width: 15px;
  margin: 0 2px;
  background-color: #bbbbbb;
  border: none;  
  border-radius: 50%;
  display: inline-block;
  opacity: 0.5;
}

.step.active {
  opacity: 1;
}

/* Mark the steps that are finished and valid: */
.step.finish {
  background-color: #4CAF50;
}
.container-login10-form-btn {
  width: 100%;
  display: -webkit-box;
  display: -webkit-flex;
  display: -moz-box;
  display: -ms-flexbox;
  display: flex;
  flex-wrap: wrap;
}

.login10-form-btn {
  display: -webkit-box;
  display: -webkit-flex;
  display: -moz-box;
  display: -ms-flexbox;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 5px;
  min-width: 100px;
  height: 50px;
  background-color: #57b846;
  border-radius:10px;

  font-family: Poppins-Regular;
  font-size: 16px;
  color: #fff;
  line-height: 1.2;

  -webkit-transition: all 0.4s;
  -o-transition: all 0.4s;
  -moz-transition: all 0.4s;
  transition: all 0.4s;
}

.login10-form-btn:hover {
  background-color: #333333;
}
   .wrap-input00 {margin-left:18%;
  width: 70%;
  position: relative;
  border-bottom: 1px solid #b2b2b2;
} </style>
    	<link rel="stylesheet" type="text/css" href="css/util.css">
<link rel="stylesheet" type="text/css" href="css/main.css">
</head>
<body>
    <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
			
				<div class="login100-form-title" style="background-image: url(images/bg-01.jpg);">
					<span class="login100-form-title-1">
						Faculty Sign Up
					</span>
				</div>
    <form id="form1" runat="server" class="auto-style1">
    
  <!-- One "tab" for each step in the form: -->
  <div class="tab"><h2>Personal Details:</h2>
      <br />
      <br />
          <p class="wrap-input00 validate-input m-b-26">
       <span class="label-input100">Faculty Name</span>
						 <asp:TextBox ID="name" class="input100"  runat="server"  BorderStyle="None" MaxLength="30"  ></asp:TextBox>
  

          </p>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="name" ErrorMessage=" * Requried" ForeColor="Red" ID="RequiredFieldValidator4"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ID="namevalidator" runat="server" ErrorMessage="Valid Name is Required" ForeColor="Red" ControlToValidate="name" 
              ValidationExpression="^[a-zA-Z\s]*" OnServerValidate="" ValidationGroup="hello" ></asp:RegularExpressionValidator>
    <p class="wrap-input00 validate-input m-b-26">
        <span class="label-input100">Date of Birth</span>
		
          <asp:TextBox ID="dob"  class="input100"  runat="server" TextMode="Date"  BorderStyle="None" MaxLength="10"></asp:TextBox>
      <span class="focus-input100"></span>

    </p>     <asp:RequiredFieldValidator runat="server" ControlToValidate="dob" ErrorMessage=" * Requried" ForeColor="Red" ID="RequiredFieldValidator2"></asp:RequiredFieldValidator>
        <br />
        <br />
        <p  class="wrap-input00 validate-input m-b-26">  
             <span class="label-input100">Aadhar Number</span>
		
            <asp:TextBox ID="aadhar"  class="input100"  MaxLength="12" runat="server" TextMode="Phone" ></asp:TextBox>
          <span class="focus-input100"></span>  </p><asp:RequiredFieldValidator runat="server" ControlToValidate="aadhar" ErrorMessage=" * Requried" ForeColor="Red" ID="RequiredFieldValidator1"></asp:RequiredFieldValidator>
          <br />
        <br />
      <p class="wrap-input00 validate-input m-b-26">
            <span class="label-input100">Father's Name</span>
		
          <asp:TextBox ID="fname"  class="input100" runat="server" ValidationGroup="hello" BorderStyle="None" MaxLength="30" ></asp:TextBox>
          <span class="focus-input100"></span>  </p> <asp:RequiredFieldValidator runat="server" ControlToValidate="fname" ErrorMessage=" * Requried" ForeColor="Red" ID="RequiredFieldValidator5"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name us Required" ForeColor="Red" ControlToValidate="fname" 
              ValidationExpression="^[a-zA-Z\s]*" OnServerValidate="" ></asp:RegularExpressionValidator>
        <br />
        <br />
      <p class="wrap-input00 validate-input m-b-26"> 
           <span class="label-input100">Mother's Name</span>
		
            <asp:TextBox ID="mname"  class="input100" runat="server" ValidationGroup="hello" MaxLength="30"></asp:TextBox>
           <span class="focus-input100"></span>  </p> <asp:RequiredFieldValidator runat="server" ControlToValidate="mname" ErrorMessage=" * Requried" ForeColor="Red" ID="RequiredFieldValidator6"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Name us Required" ForeColor="Red" ControlToValidate="mname" 
              ValidationExpression="^[a-zA-Z\s]*" OnServerValidate="" ></asp:RegularExpressionValidator>
        <br />
        <br />
         <p class="wrap-input00 validate-input m-b-26">
              <span class="label-input100">Permanent Address</span>
		<asp:TextBox ID="address"  class="input100"  MaxLength="70" runat="server"></asp:TextBox>
           <span class="focus-input100"></span> </p><asp:RequiredFieldValidator runat="server" ControlToValidate="address" ErrorMessage=" * Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
            <p class="wrap-input00 validate-input m-b-26">
                 <span class="label-input100">Mobile Number</span>
		
                <asp:TextBox ID="mob"  class="input100" runat="server" MaxLength="10"></asp:TextBox>
           <span class="focus-input100"></span> </p>
      <asp:RequiredFieldValidator runat="server" ControlToValidate="mob" ErrorMessage=" * Requried" ForeColor="Red"></asp:RequiredFieldValidator>
          <br />
       <br />
      </div>
         
        <div class="tab"><h2>Academics & User Credentials:</h2>
  
     <p class="wrap-input00 validate-input m-b-26">
       <span class="label-input100">Eligibility</span>
			 <asp:DropDownList ID="Branch" class="input100" runat="server" Height="40px"  Width="100%"  >
            <asp:ListItem>Select Branch</asp:ListItem>
            <asp:ListItem Value="CS">Computer Science &amp; Engineering</asp:ListItem>
            <asp:ListItem Value="EE">Electrical Engineering</asp:ListItem>
            <asp:ListItem Value="EC">Electronics &amp; Communication Engineering</asp:ListItem>
            <asp:ListItem Value="CE">Civil Engineering</asp:ListItem>
            <asp:ListItem Value="ME">Mechanical Engineering</asp:ListItem>
        </asp:DropDownList></p><asp:RequiredFieldValidator runat="server" ControlToValidate="Branch" ErrorMessage=" * Requried" ForeColor="Red" ID="RequiredFieldValidator12"></asp:RequiredFieldValidator>
    
        <p class="wrap-input00 validate-input m-b-26"> 
             <span class="label-input100">Email-Id</span>
		
            <asp:TextBox ID="mail" class="input100" runat="server" BorderStyle="None" MaxLength="20"></asp:TextBox>
           <span class="focus-input100"></span> </p><asp:RequiredFieldValidator runat="server" ControlToValidate="mail" ErrorMessage=" * Requried" ForeColor="Red" ID="RequiredFieldValidator7"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Please enter valid mail" ForeColor="Red" ControlToValidate="mail" 
              ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" OnServerValidate="" ></asp:RegularExpressionValidator>
       
        <p class="wrap-input00 validate-input m-b-26">
             <span class="label-input100">Password</span>
		<asp:TextBox ID="password" class="input100" runat="server"  BorderStyle="None" TextMode="Password" MaxLength="15"></asp:TextBox>
           <span class="focus-input100"></span> </p><br />
        <br />
      <p class="wrap-input00 validate-input m-b-26">
           <span class="label-input100">Confirm Password</span>
		 <asp:TextBox ID="cnfmpass" class="input100" runat="server" Font-Names="Georgia" ForeColor="#0099FF" Font-Size="Medium" BorderStyle="None" TextMode="Password" MaxLength="15"></asp:TextBox>
            <span class="focus-input100"></span> </p><asp:RequiredFieldValidator runat="server" ControlToValidate="cnfmpass" ErrorMessage=" * Requried" ForeColor="Red" ID="RequiredFieldValidator11"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Should Match with Retype Password" ForeColor="Red" ControlToValidate="cnfmpass" ControlToCompare="password"></asp:CompareValidator>
  <br />
        <br />
      
      </div>
         <div  style="overflow:auto;">
    <div style="float:right;">
      <button type="button" class="login10-form-btn" id="prevBtn" onclick="nextPrev(-1)">Previous</button>
      <button type="button" class="login10-form-btn" id="nextBtn" onclick="nextPrev(1)">Next</button>
         <asp:Button ID="Submit" class="login10-form-btn" runat="server" OnClick="Register_Click" Text="Submit"/>
 
    </div>
  </div>
  <!-- Circles which indicates the steps of the form: -->
  <div style="text-align:center;margin-top:40px;">
    <span class="step"></span>
    <span class="step"></span>
    <span class="step"></span>
    <span class="step"></span>
  </div>
</form>
    
<script>
var currentTab = 0; // Current tab is set to be the first tab (0)
showTab(currentTab); // Display the current tab

function showTab(n) {
  // This function will display the specified tab of the form...
  var x = document.getElementsByClassName("tab");
  x[n].style.display = "block";
  //... and fix the Previous/Next buttons:
  if (n == 0) {
      document.getElementById("prevBtn").style.display = "none";
      document.getElementById("Submit").style.display = "none";

  } else {
      document.getElementById("prevBtn").style.display = "inline";
      document.getElementById("Submit").style.display = "none";

  }
  if (n == (x.length - 1)) {
      document.getElementById("nextBtn").style.display = "none";
      document.getElementById("Submit").style.display = "inline";
  } else {

      document.getElementById("nextBtn").style.display = "inline";
    document.getElementById("nextBtn").innerHTML = "Next";
  }
  //... and run a function that will display the correct step indicator:
  fixStepIndicator(n)
}

function nextPrev(n) {
  // This function will figure out which tab to display
  var x = document.getElementsByClassName("tab");
  // Exit the function if any field in the current tab is invalid:
  if (n == 1 && !validateForm()) return false;
  // Hide the current tab:
  x[currentTab].style.display = "none";
  // Increase or decrease the current tab by 1:
  currentTab = currentTab + n;
  // if you have reached the end of the form...
  if (currentTab >= x.length) {
    // ... the form gets submitted:
    return false;
  }
  // Otherwise, display the correct tab:
  showTab(currentTab);
}

function validateForm() {
  // This function deals with validation of the form fields
  var x, y, i, valid = true;
  x = document.getElementsByClassName("tab");
  y = x[currentTab].getElementsByTagName("input");
  // A loop that checks every input field in the current tab:
  for (i = 0; i < y.length; i++) {
    // If a field is empty...
    if (y[i].value == "") {
      // add an "invalid" class to the field:
      y[i].className += " invalid";
      // and set the current valid status to false
      valid = false;
    }
  }
  // If the valid status is true, mark the step as finished and valid:
  if (valid) {
    document.getElementsByClassName("step")[currentTab].className += " finish";
  }
  return valid; // return the valid status
}

function fixStepIndicator(n) {
  // This function removes the "active" class of all steps...
  var i, x = document.getElementsByClassName("step");
  for (i = 0; i < x.length; i++) {
    x[i].className = x[i].className.replace(" active", "");
  }
  //... and adds the "active" class on the current step:
  x[n].className += " active";
}
</script>
</div>
</div>
		</div>
</body>
</html>



