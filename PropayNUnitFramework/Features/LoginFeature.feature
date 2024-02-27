@Login
Feature: Login

    Scenario: Login Test
        Given Navigate to Practice page
        Then Click on "Test Login Page" button
        When Enter Credentials "student" and "Password123"
        Then Click on submit button
        Then Verify that Logout button is present
        Then Click on Logout button