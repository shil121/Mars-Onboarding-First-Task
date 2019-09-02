Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@addLanguage
Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

@addSkills
Scenario Outline: To verify whether user can add Skills to his profile.
	Given I clicked on the skills tab on the profile page
	When I add a new <skill> and <skillLevel>
	Then the <skill> should be displayed on my listings
	Examples: 
	| skill       | skillLevel   |
	| Testing     | Expert       |
	| Java        | Beginner     |
	| DataAnalyst | Intermediate |

@editSkillsusingExcel
Scenario Outline: To verify whether user can edit a Skill in his profile.
	Given I clicked on the skills tab on the profile page
	When I edit a skill <skill> with <newSkill>
	Then the skill <newSkill> should be updated on my listings
	@source:skillData.xlsx
	Examples: 
	| skill | newSkill|


	@deleteSkills
	Scenario: Verify if user is able to delete a skill
	Given I clicked on the skills tab on the profile page
	When I delete a skill 'Java'
	Then the skill 'Java' should be deleted from my listings

