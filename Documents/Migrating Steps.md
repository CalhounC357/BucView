1. Make desired changes to models

2. Open the Package Manager Console in Visual Studio (if not seen, it should be found under the View tab on the top left)

3. Run the following command: `Add-Migration <migrationname> -OutputDir "Infrastructure/Migrations" -Context "BucView.Infrastructure.BucViewContext"`
Migration names are multiple words with no spaces. Example migration: `Add-Migration TestAddNewField -OutputDir "Infrastructure/Migrations" -Context "BucView.Infrastructure.BucViewContext"`

4. Once finished, there will be a migration file created under BucView/Infrastructure/Migrations. View it and make sure nothing looks too out of the ordinary. The "Up" is what adds the changes you made, and the "Down" removes those changes. Run "Remove-Migration" if it looks bad.

5. Run "Update-Database" to make the migration permanent and change the database