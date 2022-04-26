# HomeLoanCaseStudy

PROJECT DESCRIPTION:
This project is a ASP.NET MVC web-based application which provides the facility of home loan to eligible Customers. We provide a hassle-free user-friendly online platform to our users through which they can apply for loans based on their own requirements and also keep a track of their status and record during the entire process of their loan approval. We also provide features such as eligibility and emi calculators through which users can get a rough estimate of the EMI and the loan amount they are eligible for.

MODULES:
    1. LOGIN 
    2. CALCULATOR
    3. LOAN APPLICATION :
    4. ADMIN
    5.LOAN TRACKER 
           
MODULE DESCRIPTION :
1.LOGIN
A)	User – This field allows users to login with their application ID and password.      
B)	Admin – This field allows authorized admin to login.

2.CALCULATOR :
This field consists of two sub-modules as follows-:
A)	Eligibility Calculator :
The eligibility calculator receives user’s monthly income and shows the loan amount the user is eligible for using following calculations:
Loan amount = 60 * (0.6 * net monthly salary) 

B)	EMI calculator: 
The EMI Calculator receives the loan amount and the loan tenure required keeping the interest rate constant at 8.5% and calculates the monthly EMI based on following Calculations:
EMI = P*R*{((1+R)^n)/((1+R)^n-1)}

3.LOAN APPLICATION
The application page has following three sections-:
A)	Income Details – 
It provides fields for income details such as property location,
Property name, estimated cost of property etc. 
B)	Loan Details – 
It provides fields for loan details such as amount required,
user’s monthly income, etc. 
C)	Personal Details -  
It takes details such as users name, age, DOB, Personal identification details such as Aadhar card, pan card no, etc.
D)	Documents upload
The user can upload the digital scanned copies of aadhar card, pan card, collateral etc.       

On completion of above procedures your application will be submitted for verification. 
 
4. LOAN TRACKER 
            
You can track the current status of your loan as following
1)	Sent for verification
2)	Verified and sent for final approval
3)	Approved/rejected           

5. ACCOUNT CREATION 
           
Once your loan is approved an account is created by generating an account number and the loan amount is transferred to your account.
