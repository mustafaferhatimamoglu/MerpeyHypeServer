# MerpeyHypeServer
Desc

#rest proccess with grapevine https://github.com/scottoffen/grapevine-legacy

#DB 
Install-Package Microsoft.EntityFrameworkCore.Tools 
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Scaffold-DbContext "Data Source=.;Initial Catalog=MERPEYHYPEUSER;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelUser
