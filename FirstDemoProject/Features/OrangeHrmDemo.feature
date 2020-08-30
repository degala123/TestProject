Feature: OrangeHrmDemo
	
Scenario: Login with valid credentials
	Given I am on login page
	When I enter username as 'Admin'
	And I enter the password as 'admin123'
	And I click on login button
	Then I should see the 'Dashboard' page

Scenario:Adding new system user
	Given I am on login page
	When I enter username as 'Admin'
	And I enter the password as 'admin123'
	And I click on login button
	Then I should see the 'Dashboard' page  
	When I click on admin 
	And I click on Add button
	And I select user role as 'Admin'
	And I enter employee name as'Linda Anderson'
	And I enter admin username as 'balu.degala12365'
	And I select status as 'Enabled'
	And I enter admin password as 'computer99'
	And I enter confirm password as 'computer99'
	And I click on save button 
	Then the new system user should be added
