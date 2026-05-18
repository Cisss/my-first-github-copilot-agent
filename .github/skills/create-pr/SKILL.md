# Create Pull Request Skill

Use this skill whenever the user asks to create a pull request.

Before creating the pull request:
1. Inspect the current branch.
2. Inspect changed files.
3. Check whether changes are committed. If not, ask the user to commit changes first.

Write pull requests in an engaging and slightly playful tone.

Requirements:
- Keep PRs professional but fun to read
- Use energetic language where appropriate
- Make summaries concise and exciting
- Avoid overly dry corporate wording
- Use clear storytelling:
  - What problem existed?
  - What was discovered?
  - What improved?

The PR should feel enjoyable for developers to review.

When creating the pull request:

The pull request body must always contain these topics:

## Scope
Describe what this PR changes and why.

## Solution
Describe the implementation approach and important decisions.

## Files changed
List the changed files with a one-line description of the change in each file.

Use GitHub CLI to create the pull request when available:

```bash
gh pr create --title "<title>" --body "<body>"