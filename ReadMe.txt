https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97
https://stackoverflow.com/questions/23999926/updating-user-role-using-asp-net-identity
https://channel9.msdn.com/Series/Customizing-ASPNET-Authentication-with-Identity/01
https://www.youtube.com/watch?v=nfTfwEckPpYhttps://github.com/SinSarak/AuthorUser/blob/master/ReadMe.txt
https://blog.codingmilitia.com/2019/04/29/aspnet-019-from-zero-to-overkill-roles-claims-policies
https://stackoverflow.com/questions/41940905/asp-net-mvc-how-to-create-a-custom-role-provider
https://stackoverflow.com/questions/22074474/redirect-unauthorized-page-access-in-mvc-to-custom-view



1.Register User
2.Assign User to Role Admin (to access all features)
3.Create RoleClaim:
	a. Claim1    (main claim)
	b. SubClaim 1.1  (sub claim of Claim1)
	c. SubClaim 1.2  (sub claim of Claim2)
	d. SubClaim 1.3  (sub claim of Claim3)
4.Assign User to RoleClaim
5.Test Action in HomeController