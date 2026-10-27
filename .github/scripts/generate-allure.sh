#!/usr/bin/env bash
set -euo pipefail

: "${SOURCE_RUN_ID:?SOURCE_RUN_ID must be set}"
: "${GITHUB_REPOSITORY:?GITHUB_REPOSITORY must be set}"

if [[ ! "$SOURCE_RUN_ID" =~ ^[0-9]+$ ]]; then
  echo "::error::SOURCE_RUN_ID must be numeric: $SOURCE_RUN_ID"
  exit 1
fi
if [[ ! "$GITHUB_REPOSITORY" =~ ^[a-zA-Z0-9_.-]+/[a-zA-Z0-9_.-]+$ ]]; then
  echo "::error::Invalid GITHUB_REPOSITORY"
  exit 1
fi

mkdir -p allure-site

for entry in \
  'api-test-results|api|API' \
  'ui-results-chrome|ui/chrome|Chrome' \
  'ui-results-firefox|ui/firefox|Firefox' \
  'ui-results-edge|ui/edge|Edge'; do

  IFS='|' read -r artifact target browser <<< "$entry"
  artifact_dir="downloaded-results/$artifact"

  if [[ ! -d "$artifact_dir" ]]; then
    echo "::error::Missing artifact: $artifact"
    exit 1
  fi

  results_dir="$(find "$artifact_dir" -type d -name allure-results -print -quit)"
  if [[ -z "$results_dir" ]]; then
    echo "::error::Missing allure-results directory in $artifact"
    exit 1
  fi

  result_file="$(find "$results_dir" -maxdepth 1 -type f -name '*-result.json' -print -quit)"
  if [[ -z "$result_file" ]]; then
    echo "::error::No Allure test result JSON files in $artifact"
    exit 1
  fi

  printf 'Test group=%s\nEnvironment=GitHub Actions\nOS=Windows\n' "$browser" > "$results_dir/environment.properties"
  cat > "$results_dir/executor.json" <<EOF
{
  "name": "GitHub Actions",
  "type": "github",
  "buildName": "Qase run ${SOURCE_RUN_ID}",
  "buildUrl": "https://github.com/${GITHUB_REPOSITORY}/actions/runs/${SOURCE_RUN_ID}"
}
EOF

  echo "Generating Allure report: $artifact -> allure-site/$target"
  allure generate "$results_dir" --clean --output "allure-site/$target"
  if [[ ! -f "allure-site/$target/index.html" ]]; then
    echo "::error::Allure did not create index.html for $artifact"
    exit 1
  fi
done

sed \
  -e "s|__SOURCE_RUN_ID__|${SOURCE_RUN_ID}|g" \
  -e "s|__REPOSITORY__|${GITHUB_REPOSITORY}|g" \
  .github/templates/allure-index.html > allure-site/index.html

echo "Allure reports generated successfully."
