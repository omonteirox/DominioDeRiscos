# Domínio de Riscos

- Linguagem Ubíquoa com o cliente e sua importância em cenários reais
- Dividir para conquistar é importante
- Domínio Anêmico
  - Só reflete o que está no banco, vai fazer as verificações por Store procedures no banco. (Não é possível testar as procedures).
- Domínio Rico
  - Faz as verificações no próprio código, facilitando os testes automatizados. (Não deixar os testes no banco é melhor, pois o C# consegue pegar os erros em tempo de compilação)
  - O foco é deixar todas as regras de negócio no domínio e não no banco. (Tudo que é condicional preferencialmente tem que estar dentro da aplicação e não no banco.)
  - O banco de dados se torna apenas um repositório de informações.
- Subdomínios
  - É a quebra dos domínio em várias outras partes
  - Dividir para conquistar!!!
- Separação de Contextos Delimitados
 - Você dividir os contextos, facilita a manutenção mas aumenta a complexidade
  - Mais adaptativo às mudanças
# Payment.Domain

É o domínio Rico, onde vai conter os Commands, Entities, VO's.

# Payment Shared

É o domínio compartilhado, onde existirão alguns contratos para serem implementados.

# Payment Test

É onde fica localizado os testes, parte fundamental para manter a manutenção do sistema efetiva.

  
