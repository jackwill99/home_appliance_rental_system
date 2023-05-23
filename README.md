# HOME RENTAL APPLIANCE SYSTEM

-   Programming language (C#)
-   Database (MsSql)
-   I'm linking the database from C# using `connectionString`. So, when you run this program, you must change the `serverName` infront of the `connectionString` to your `MsSql Server Name`. You can get your serverName in `Sql Management Studio`. If you are not configured `connectionString`, you will get an error :( .

<a name="_toc128556033"></a>

# <a name="_toc133709500"></a>**Introduction**

`	`The Home Appliance Rental System is an innovative solution designed for renting electrical appliances ranging from small to large for a minimum of one month. The system is accessible to two types of users: the administrator and the customers. The administrator has the authority to carry out various functions such as viewing, adding, editing, deleting and updating, while the customers can only view and rent. To use the system, both types of users must first register successfully. Upon registration, users can log in using their username and password. The system enforces strict password requirements, where the password must contain characters between 8 and 16, at least one uppercase and one lowercase letter. It is mandatory for both users to remember their login details to access the system. The implementation includes a well-defined design, thorough implementation and employs special methods such as encapsulation to ensure the system's efficiency. Additionally, testing has been carried out to ensure that the program can handle human errors effectively. Lastly, a detailed class diagram with explanations is provided to enhance the system's usability.

### <a name="_toc133709505"></a>**(i) Design of Program**

**Start Form**

`	`Start Form is main form of Home Appliance Rental System that can choose ways dependent on the user type, admin or customer.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.014.png)

Figure; Start Form

**Admin Registration Form**

This form is for admin registration and it is for saving admin information in database. As the important thing, the new admins need to remind their username and password that had been filled in the register form to use in login form.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.015.png)

Figure; Admin Registration Form

**Admin Login Form**

`	`This form is used to login to the home appliances rental system and if the user is new, the user can click “Register Here” and then the register form will appear to register.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.016.png)

Figure; Admin Login Form

**Admin Home Page**

Admin Home will appear after the admin successfully login to the home appliance rental system. In admin home, the admin can add, delete and update Appliances and Appliance Types by clicking Appliance in menu bar and can select for appliance or appliance type and can also view lists of admins, customers, appliances and rent by clicking list.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.017.png)

Figure: Admin Home Page

**Appliance Type Form**

`	`This form is for registration Appliance Type. To register new appliance type, the user needs to add Appliance Type. In this form, the user can add appliance type and the user will be the admin.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.018.png)

Figure; Appliance Type Form

**Appliance Entry Form**
\*\*
`	`Appliance Entry will appear after the admin had clicked appliances in menu bar and chosen appliance entry. In here, the admin can delete, update and add appliances by selecting from data grid view and can see update appliances in data grid view.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.019.png)

Figure; Appliance Entry Form

**Appliance List Form**

`	`The admin can see appliance list in details and can search appliances with appliance type. If they want to delete or update appliances, the admin can go to appliance entry form and can do. And user can update and delete the appliance entry.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.020.png)

Figure; Appliance List Form

**Admin List Form**

`	`The objective of this form is to show how many admins there are. If one of the admins is out or resign, the other admin can delete the data of resigned staff in here.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.021.png)

Figure; Admin List Form

**Customer List Form**

`	`This form is seen by admin and the objective is to know customers count.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.022.png)

Figure; Customer List Form

**Rent List Form**

`	`The admin can know total rented appliances in this form and can check stock of appliances and can search rent list.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.023.png)

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.024.png)

Figure; Rent List Form and detail of rent list entry

**Customer Registration Form**

`	`This form is used to register for customers. After registration, the customer can login to use the home appliance rental system. As the admin user, the customers must note their username and password to fill in the login form to login.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.025.png)

Figure; Customer Registration Form

**Customer Login Form**

`	`If the customers want to use home appliances rental system, they need to login. So, this form is for customer login. If the customer is new, firstly they can register by clicking “Register Here” and the customer registration form will appear.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.026.png)

Figure; Customer Login Form

**Customer Home Form**

`	`This form is Home Page for Customers. In this form, the customer can add Appliances to rent and then they can rent. They can view appliance in details and can also view rent details.

![](md.assets/Aspose.Words.6d016eca-a4d9-4553-9be8-e947e0e006e1.027.png)

Figure; Customer Home Form
