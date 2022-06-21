import radius as radius {
  foo: 'foo'
}

resource env 'Applications.Core/environments@2022-03-15-privatepreview' = {
  name: 'prayingthiswor2'
  location: 'westus2'
  properties: {
    compute:{
      kind: 'kubernetes'
    }
  }
}

module foo 'test2.bicep' = {
  name: 'test'
  params: {
    foo: 'bar'
  }
}
