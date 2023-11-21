.PHONY: setup
setup:
	docker-compose build

.PHONY: build
build:
	docker-compose build assessment-person-a-p-i

.PHONY: serve
serve:
	docker-compose build assessment-person-a-p-i && docker-compose up assessment-person-a-p-i

.PHONY: shell
shell:
	docker-compose run assessment-person-a-p-i bash

.PHONY: test
test:
	docker-compose up test-database & docker-compose build assessment-person-a-p-i-test && docker-compose up assessment-person-a-p-i-test

.PHONY: lint
lint:
	-dotnet tool install -g dotnet-format
	dotnet tool update -g dotnet-format
	dotnet format

.PHONY: restart-db
restart-db:
	docker stop $$(docker ps -q --filter ancestor=test-database -a)
	-docker rm $$(docker ps -q --filter ancestor=test-database -a)
	docker rmi test-database
	docker-compose up -d test-database
