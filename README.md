<!-- Title -->

<p align="center">
  <h2 align="center">Clean Achitecture Templates</h2>
  <img src="imgs/Banners-Dark.png" >
</p>
    
 <!-- ABOUT THE PROJECT -->
# About the project
Welcome everyone to the second edition of He4rtoberfest, an event by He4rt Developers to encourage new developers to participate in Hacktoberfest by DigitalOcean and learn a little more about the idea of ​​open source.

The idea is based on taking project structures that we usually use and transforming them into templates to speed up the development of new projects, from the simplest to the most complex, and doing them in the most varied architectures and packages, showing the greatest number of possible ways to solve the problem. same problem.

##
<!-- ROADMAP OF PROJECT -->

## Examples to be developed

In the list below will be all the exercises that we will accept in our pull requests.

- [1 - Clean Achitecture CQRS Entity Framework]()
- [2 - Clean Architecture CQRS Dapper]()
- [3 - Clean Architecture CQRS NHibernate]()
- [4 - WebApi JWT Token Auth]()
- [5 - Clean Architecture Identity4]()

If you want to give suggestions for challenges, contact a moderator.
  
<!-- CONTRIBUTING -->

## How to participate

Contributions make the open source community an amazing place to learn, inspire and create. all contributions
are **extremely appreciated**

However, as this will be an event, there will be some rules to follow in order for you to be approved and it is not complex. Understand:

- In order for you to have an approved Pull Request (PR) linked to Hacktoberfest, you will have to do a PR of **challenge 1** (1 - Clean Achitecture CQRS Entity Framework);


When you create the branch to send the Pull Request, you should follow the example below:

1. Fork the project
2. Go to the fork repository on your github and in the code part copy the link to clone (HTTPS or SSH)
3. Open the terminal, choose a folder of your choice and make a clone git clone paste the link you copied
4. Create a folder of the language you chose in the `challenges/id_challenge/template_name/` directory
5. Then, inside this lang folder, create the folder with your nickname, thus `challenges/id_challenge/name_template/nickname`
6. Solve the challenge
7. Copy the model.md to your folder, fill in the information described and rename the file to **README.MD**
8. Create a branch with the challenge following the template beside `(git checkout -b challenges/id_challenge/template_name/nickname)`
9. Then do `git add .`
10. Commit `(git commit -m 'Finishing the challenge')`
11. Push the Branch `(git push origin challenges/id_challenge/lang/nickname)`
13. Open a Pull Request

## Pull Requests Review

As our goal will be to give the best experience possible to the participant, we will have some basic code review rules to make it an interesting experience for those who are applying the challenge, namely:

- Reinforce code reading and typing when possible;
- Typing/grammatical errors and variable names without a context, such as [a,b,c,x,y,z] will have to be changed;
- Function isolation when necessary can also be requested.

Any questions, you can go to our [question bank](https://github.com/MarcosFerreira17/clean-architecture_templates/issues) and ask.

## Updating your fork

If this repository is updated with new exercises you need to update your fork

```bash
#1. Switch to the main branch
git checkout main
# 2. Check if your local copy has a link to the original
git remote -v
#3. If not, add the original link
git remote add upstream git@github.com:MarcosFerreira17/clean-architecture_templates.git
# or
git remote add upstream https://github.com/MarcosFerreira17/clean-architecture_templates.git
#4. Confirm the link has been added
git remote -v
#5. You can now fetch the original repo, assuming the link name is 'upstream'
git fetch upstream
# 6. Merge updates to your main branch
git merge upstream/main main
#7. Push your fork with the new changes
git push origin main
```

## Complementary materials

- [**Git4Noobs**](https://github.com/danielhe4rt/git4noobs)
- [**Learning about Git and Github**](https://www.youtube.com/watch?v=_LNWekPPS9w)
