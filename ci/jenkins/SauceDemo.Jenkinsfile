pipeline {
    agent any

    parameters {
        string(
            name: 'PROJECT_DIR',
            defaultValue: 'Lesson20_HW_9/HW9_1',
            description: 'Путь к проекту от корня репозитория'
        )

        string(
            name: 'SOLUTION',
            defaultValue: 'HW9_1.sln',
            description: 'Имя solution-файла'
        )

        string(
            name: 'TEST_PROJECT',
            defaultValue: 'HW9_1.Tests/HW9_1.Tests.csproj',
            description: 'Путь к тестовому проекту'
        )

        choice(
            name: 'TARGET_BROWSER',
            choices: ['All', 'Chrome', 'Firefox', 'Edge'],
            description: 'Браузер для запуска тестов'
        )
    }

    environment {
        EXECUTION_MODE = 'Remote'
        GRID_URL = 'http://selenium-hub:4444'
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
    }

    stages {
        stage('Restore') {
            steps {
                dir(params.PROJECT_DIR) {
                    sh "dotnet restore ${params.SOLUTION}"
                }
            }
        }

        stage('Build') {
            steps {
                dir(params.PROJECT_DIR) {
                    sh "dotnet build ${params.SOLUTION} --no-restore"
                }
            }
        }

        stage('Clean Allure Results') {
            steps {
                dir(params.PROJECT_DIR) {
                    sh 'rm -rf HW9_1.Tests/allure-results'
                }
            }
        }

        stage('Tests') {
            matrix {
                axes {
                    axis {
                        name 'BROWSER'
                        values 'Chrome', 'Firefox', 'Edge'
                    }
                }

                stages {
                    stage('Run Tests') {
                        when {
                            expression {
                                params.TARGET_BROWSER == 'All' ||
                                params.TARGET_BROWSER == env.BROWSER
                            }
                        }

                        steps {
                            dir(params.PROJECT_DIR) {
                                sh "dotnet test ${params.TEST_PROJECT} --no-build"
                            }
                        }
                    }
                }
            }
        }

        stage('Allure Report') {
            steps {
                dir(params.PROJECT_DIR) {
                    allure commandline: 'allure Jenkins',
                           includeProperties: false,
                           results: [[path: 'HW9_1.Tests/allure-results']]
                }
            }
        }
    }
}