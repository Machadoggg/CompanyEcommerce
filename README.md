{
  "openapi": "3.0.1",
  "info": {
    "title": "Company Technology Services API Market",
    "description": "Simple example ASP .NET Core Web API",
    "contact": {
      "name": "Send to email to Jorge Machado",
      "email": "machadoggg@gmail.com"
    },
    "license": {
      "name": "Use License"
    },
    "version": "v1"
  },
  "paths": {
    "/api/Customers/Insert": {
      "post": {
        "tags": [
          "Customers"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Customers/Update": {
      "put": {
        "tags": [
          "Customers"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Customers/Delete/{CustomerId}": {
      "delete": {
        "tags": [
          "Customers"
        ],
        "parameters": [
          {
            "name": "CustomerId",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Customers/Get/{CustomerId}": {
      "get": {
        "tags": [
          "Customers"
        ],
        "parameters": [
          {
            "name": "CustomerId",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Customers/GetAll": {
      "get": {
        "tags": [
          "Customers"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Customers/InsertAsync": {
      "post": {
        "tags": [
          "Customers"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Customers/UpdateAsync": {
      "put": {
        "tags": [
          "Customers"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomersDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Customers/DeleteAsync/{CustomerId}": {
      "delete": {
        "tags": [
          "Customers"
        ],
        "parameters": [
          {
            "name": "CustomerId",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Customers/GetAsync/{CustomerId}": {
      "get": {
        "tags": [
          "Customers"
        ],
        "parameters": [
          {
            "name": "CustomerId",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Customers/GetAllAsync": {
      "get": {
        "tags": [
          "Customers"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/WeatherForecast": {
      "get": {
        "tags": [
          "WeatherForecast"
        ],
        "operationId": "GetWeatherForecast",
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              }
            }
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "CustomersDto": {
        "type": "object",
        "properties": {
          "customerId": {
            "type": "string",
            "nullable": true
          },
          "companyName": {
            "type": "string",
            "nullable": true
          },
          "contactName": {
            "type": "string",
            "nullable": true
          },
          "contactTitle": {
            "type": "string",
            "nullable": true
          },
          "address": {
            "type": "string",
            "nullable": true
          },
          "city": {
            "type": "string",
            "nullable": true
          },
          "region": {
            "type": "string",
            "nullable": true
          },
          "postalCode": {
            "type": "string",
            "nullable": true
          },
          "country": {
            "type": "string",
            "nullable": true
          },
          "phone": {
            "type": "string",
            "nullable": true
          },
          "fax": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "WeatherForecast": {
        "type": "object",
        "properties": {
          "date": {
            "type": "string",
            "format": "date"
          },
          "temperatureC": {
            "type": "integer",
            "format": "int32"
          },
          "temperatureF": {
            "type": "integer",
            "format": "int32",
            "readOnly": true
          },
          "summary": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    }
  }
}
