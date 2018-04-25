[![Build Status](https://travis-ci.com/tomkerkhove/gdpr-with-azure.svg?token=GsSXSXe5xF8ZdYK5qExq&branch=master)](https://travis-ci.com/tomkerkhove/gdpr-with-azure)

# How to be GDPR compliant in Azure
Themis Inc. is a fictiuous company that provides a SaaS platform. This SaaS platform stores personal data and integrates with the StackExchange data sets.
With GDPR they need to change their platform so that they are compliant.

This sample covers the following scenarios on how you can use Microsoft Azure services to be GDPR compliant:

- [Make user information available on request](#Make-user-information-available-on-request)

## Make user information available on request
[Discussion in issues #1](https://github.com/tomkerkhove/gdpr-with-azure/issues/1)

A user needs to be capable of requesting a copy of all the stored information about a specific user. This includes both personal identifiable data, such as user profile, and application data which is the data stored by Themis Inc. that includes the StackExchange data sets.

The user data consolidation is an asynchronous process where the user can request this in the portal which starts the consolidation process.
Once this is completed, the user will receive an email with a link where they can download their data up to 7 days.

![Scenario - Make user information available on request](media/consolidate-user-data.png)
