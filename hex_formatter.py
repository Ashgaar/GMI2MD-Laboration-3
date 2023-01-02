# hex_formatter.py
##
print('Will produce 0xaa, 0xbb if aabb is entered.')
inputstring = input("Write a hex string:\n")
array = list(inputstring)
length = len(array)+(len(array)/2)-1

for i in range(2, int(length), 3):
    array.insert(i, ', 0x')

array.insert(0, '0x')

output = ""
for i in array:
    output += i

print(output)
input("Press enter key to quit ...")
