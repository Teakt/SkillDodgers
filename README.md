# SkillDodger

Gucci gang

# SkillDodger

[![pipeline status](https://gitlab.com/Gunteak/SkillDodger/badges/master/pipeline.svg)](https://gitlab.com/Gunteak/SkillDodger/commits/master)

## Repository
The repository is only used to host current version of the project and Unity related things.  
For non-Unity related things, please consider using the Drive.
## Configuration
As we don't want any problem using GitLab with the full team, we all have to follow the same configuration.  
First of all, the current project is located in the Project folder.  
When opening Unity for the first time, please go to : 
* **Edit** -> **Project Settings** -> **Editor**
* In **Version Control** -> **Mode**, choose the option **Visible Meta Files**
* In **Asset Serialization** -> **Mode**, choose the option **Force Text** 

## Using Git
First, you need to download Git : https://git-scm.com/downloads  
Secondly, you need to create a GitLab account : https://gitlab.com/ 

* git clone https://gitlab.com/Gunteak/SkillDodger.git
This command will make a local copy of the repository

* git branch NameOfYourBranch  
This command will create a new branch in your local copy  
You should create a new branch per feature

* git checkout NameOfYourBranch  
This command will change your local repository to the branch you specified

* git status  
This command will show the current changes in your local repository compares to the main repository

* git add YourModifiedFile
This command will add the changed file to the next commit. Putting * will add all the files

* git rm YourDeletedFile  
This command will remove the specified file in the next commit.

* git commit -m "YourMessage"  
This command will make a commit (~update) to your current branch.

* git push  
This command will submit your current commits to the main repository  

* git pull  
This command will get the current version of files in the main repository


In general, you should create a new branch for your new feature, then add your commits to it. 
When the feature is correctly added, you should push it.  

Then go onto the project page, select your branch, and then search for the "Create Merge Request" button and fill the data for the merge request.  

Then, the next step is to notify one of the admin of the project, you can use the Trello and link your merge request to the card you have worked on.

Then, someone is gonna review it and your commit will be merged on the current version of the project !

## Workflow  

First time :
- git clone https://gitlab.com/Gunteak/SkillDodger.git

Starting to work :
- git status
- git checkout master
- git pull
- git branch MyNewBranch
- git checkout MyNewBranch
- git status

Submit your work :
- git status
- git add *
- git status
- git commit -m "MyMesssage"
- git push

Validation process :
- Create a merge request
- Post your merge request on Trello
